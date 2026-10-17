using System.ComponentModel.DataAnnotations;
using WinFormsApp2.data.DAO;
using WinFormsApp2.data.entity;

namespace WinFormsApp2.bul;

public class StudentBusiness
{
    private readonly StudentDataAccess _studentDataAccess;
    private readonly ClassBusiness _classBusiness;

    public StudentBusiness(StudentDataAccess studentDataAccess, ClassBusiness classBusiness)
    {
        _studentDataAccess = studentDataAccess;
        _classBusiness = classBusiness;
    }

    public List<Student> GetAll()
    {
        return _studentDataAccess.GetAll();
    }

    public Student? GetById(string studentId)
    {
        return _studentDataAccess.GetById(NormalizeStudentId(studentId));
    }

    public List<Student> GetByClassCode(string classCode)
    {
        return _studentDataAccess.GetByClassCode(classCode.Trim());
    }

    public List<Student> SearchByStudentId(string keyword)
    {
        var normalizedKeyword = keyword.Trim();
        return normalizedKeyword.Length == 0
            ? GetAll()
            : _studentDataAccess.SearchByStudentId(normalizedKeyword);
    }

    public List<Student> Search(string field, string keyword)
    {
        var normalizedKeyword = keyword.Trim();
        return normalizedKeyword.Length == 0
            ? GetAll()
            : _studentDataAccess.Search(field, normalizedKeyword);
    }

    public bool TryAdd(Student student, string? classCode, out List<string> errors)
    {
        var validationErrors = new List<ValidationResult>();
        var succeeded = TryAddValidated(student, classCode, out validationErrors);
        errors = validationErrors.Select(error => error.ErrorMessage ?? "Invalid student data.").ToList();
        return succeeded;
    }

    public bool TryAddValidated(Student student, string? classCode, out List<ValidationResult> errors)
    {
        Normalize(student, classCode, out classCode);
        errors = Validate(student, classCode);

        if (_studentDataAccess.GetById(student.StudentId) is not null)
        {
            errors.Add(new ValidationResult("StudentId already exists.", new[] { nameof(Student.StudentId) }));
        }

        if (errors.Count > 0)
        {
            return false;
        }

        student.Class = ResolveClass(classCode);
        _studentDataAccess.Add(student);
        student.Class?.Students.Add(student);
        return true;
    }

    public bool TryUpdate(string studentId, Student updatedStudent, string? classCode, out List<string> errors)
    {
        var validationErrors = new List<ValidationResult>();
        var succeeded = TryUpdateValidated(studentId, updatedStudent, classCode, out validationErrors);
        errors = validationErrors.Select(error => error.ErrorMessage ?? "Invalid student data.").ToList();
        return succeeded;
    }

    public bool TryUpdateValidated(string studentId, Student updatedStudent, string? classCode, out List<ValidationResult> errors)
    {
        studentId = NormalizeStudentId(studentId);
        var existingStudent = _studentDataAccess.GetById(studentId);
        errors = new List<ValidationResult>();
        if (existingStudent is null)
        {
            errors.Add(new ValidationResult("Student was not found.", new[] { nameof(Student.StudentId) }));
            return false;
        }

        updatedStudent.StudentId = existingStudent.StudentId;
        Normalize(updatedStudent, classCode, out classCode);
        errors = Validate(updatedStudent, classCode);
        if (errors.Count > 0)
        {
            return false;
        }

        updatedStudent.Class = ResolveClass(classCode);
        if (existingStudent.Class != updatedStudent.Class)
        {
            existingStudent.Class?.Students.Remove(existingStudent);
            updatedStudent.Class?.Students.Add(existingStudent);
        }

        _studentDataAccess.Update(updatedStudent);
        return true;
    }

    public bool Delete(string studentId)
    {
        studentId = NormalizeStudentId(studentId);
        var student = _studentDataAccess.GetById(studentId);
        if (student is null)
        {
            return false;
        }

        student.Class?.Students.Remove(student);
        return _studentDataAccess.Delete(studentId);
    }

    public List<ValidationResult> ValidateStudent(Student student, string? classCode)
    {
        Normalize(student, classCode, out classCode);
        return Validate(student, classCode);
    }

    private List<ValidationResult> Validate(Student student, string? classCode)
    {
        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(student);
        Validator.TryValidateObject(student, validationContext, validationResults, validateAllProperties: true);

        if (!string.IsNullOrWhiteSpace(classCode) && !_classBusiness.IsValidCode(classCode))
        {
            validationResults.Add(new ValidationResult("Class code must follow CSE + 4 digits.", new[] { nameof(Student.Class) }));
        }

        return validationResults;
    }

    private ClassModel? ResolveClass(string? classCode)
    {
        return string.IsNullOrWhiteSpace(classCode) ? null : _classBusiness.GetOrCreate(classCode.Trim().ToUpperInvariant());
    }

    private static void Normalize(Student student, string? classCode, out string? normalizedClassCode)
    {
        student.StudentId = NormalizeStudentId(student.StudentId);
        student.FullName = string.Join(' ', student.FullName.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries));
        student.Email = student.Email.Trim().ToLowerInvariant();
        student.Phone = student.Phone.Trim();
        student.Status = student.Status.Trim();
        normalizedClassCode = string.IsNullOrWhiteSpace(classCode) ? null : classCode.Trim().ToUpperInvariant();
    }

    private static string NormalizeStudentId(string studentId)
    {
        return studentId.Trim().ToUpperInvariant();
    }

    private static bool Contains(string? value, string keyword)
    {
        return value?.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true;
    }
}
