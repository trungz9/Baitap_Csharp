using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class StudentDAO
{
    private List<Student> students = new List<Student>();


    // =========================
    // VALIDATE STUDENT
    // =========================
    private bool ValidateStudent(Student student)
    {
        var context = new ValidationContext(student);

        var results = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(
            student,
            context,
            results,
            validateAllProperties: true
        );

        if (!isValid)
        {
            Console.WriteLine("Dữ liệu Student không hợp lệ:");

            foreach (var error in results)
            {
                Console.WriteLine("- " + error.ErrorMessage);
            }
        }

        return isValid;
    }


    // =========================
    // ADD
    // =========================
    public bool Add(Student student)
    {
        // Kiểm tra object
        if (!ValidateStudent(student))
        {
            return false;
        }

        // Kiểm tra ID đã tồn tại chưa
        if (students.Any(s => s.Id == student.Id))
        {
            Console.WriteLine("ID đã tồn tại!");
            return false;
        }

        students.Add(student);

        Console.WriteLine("Thêm Student thành công!");

        return true;
    }


    // =========================
    // EDIT
    // =========================
    public bool Edit(Student student)
    {
        // Validate object
        if (!ValidateStudent(student))
        {
            return false;
        }

        Student oldStudent = GetById(student.Id);

        if (oldStudent == null)
        {
            Console.WriteLine("Không tìm thấy Student!");
            return false;
        }

        oldStudent.Name = student.Name;
        oldStudent.Age = student.Age;
        oldStudent.Email = student.Email;
        oldStudent.GPA = student.GPA;

        Console.WriteLine("Sửa Student thành công!");

        return true;
    }


    // =========================
    // DELETE
    // =========================
    public bool Delete(string id)
    {
        Student student = GetById(id);

        if (student == null)
        {
            Console.WriteLine("Không tìm thấy Student!");
            return false;
        }

        students.Remove(student);

        Console.WriteLine("Xóa Student thành công!");

        return true;
    }


    // =========================
    // GET ALL
    // =========================
    public List<Student> GetAlls()
    {
        return students;
    }


    // =========================
    // GET BY ID
    // =========================
    public Student GetById(string id)
    {
        return students.FirstOrDefault(s => s.Id == id);
    }


    // =========================
    // GET BY NAME
    // =========================
    public List<Student> GetByName(string name)
    {
        return students
            .Where(s => s.Name.Contains(
                name,
                StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}