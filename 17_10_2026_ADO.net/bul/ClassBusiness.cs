using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using WinFormsApp2.data.DAO;
using WinFormsApp2.data.entity;

namespace WinFormsApp2.bul;

public class ClassBusiness
{
    private static readonly Regex ClassCodeRegex = new("^CSE\\d{4}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
    private readonly ClassDataAccess _classDataAccess;

    public ClassBusiness(ClassDataAccess classDataAccess)
    {
        _classDataAccess = classDataAccess;
    }

    public List<ClassModel> GetAll()
    {
        return _classDataAccess.GetAll();
    }

    public ClassModel? GetByCode(string code)
    {
        return _classDataAccess.GetByCode(code);
    }

    public bool TryAdd(ClassModel classModel, out List<string> errors)
    {
        errors = Validate(classModel);
        if (_classDataAccess.GetByCode(classModel.Code) is not null)
        {
            errors.Add("Class code already exists.");
        }

        if (errors.Count > 0)
        {
            return false;
        }

        _classDataAccess.Add(classModel);
        return true;
    }

    public bool TryUpdate(string code, string name, out List<string> errors)
    {
        var classModel = _classDataAccess.GetByCode(code);
        if (classModel is null)
        {
            errors = new List<string> { "Class was not found." };
            return false;
        }

        var updatedClass = new ClassModel { Code = classModel.Code, Name = name };
        errors = Validate(updatedClass);
        if (errors.Count > 0)
        {
            return false;
        }

        classModel.Name = updatedClass.Name;
        _classDataAccess.Update(classModel);
        return true;
    }

    public bool Delete(string code)
    {
        return _classDataAccess.GetByCode(code) is not null
            && !_classDataAccess.HasStudents(code)
            && _classDataAccess.Delete(code);
    }

    public bool IsValidCode(string? code)
    {
        return !string.IsNullOrWhiteSpace(code) && ClassCodeRegex.IsMatch(code);
    }

    public ClassModel GetOrCreate(string code)
    {
        var existingClass = _classDataAccess.GetByCode(code);
        if (existingClass is not null)
        {
            return existingClass;
        }

        var classModel = new ClassModel { Code = code, Name = code };
        _classDataAccess.Add(classModel);
        return classModel;
    }

    private List<string> Validate(ClassModel classModel)
    {
        var validationResults = new List<ValidationResult>();
        Validator.TryValidateObject(classModel, new ValidationContext(classModel), validationResults, validateAllProperties: true);
        return validationResults
            .Select(result => result.ErrorMessage ?? "Invalid class data.")
            .ToList();
    }
}
