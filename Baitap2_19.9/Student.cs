using System;
using System.ComponentModel.DataAnnotations;

public class Student
{
    [Required(ErrorMessage = "ID không được để trống")]
    [StringLength(10, MinimumLength = 3,
        ErrorMessage = "ID phải có từ 3 đến 10 ký tự")]
    public string Id { get; set; }


    [Required(ErrorMessage = "Tên không được để trống")]
    [StringLength(50, MinimumLength = 2,
        ErrorMessage = "Tên phải có từ 2 đến 50 ký tự")]
    public string Name { get; set; }


    [Range(18, 60,
        ErrorMessage = "Tuổi phải nằm trong khoảng từ 18 đến 60")]
    public int Age { get; set; }


    [Required(ErrorMessage = "Email không được để trống")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
    public string Email { get; set; }


    [Range(0, 4,
        ErrorMessage = "GPA phải nằm trong khoảng từ 0 đến 4")]
    public double GPA { get; set; }


    public Student()
    {
    }


    public Student(string id, string name, int age,
                   string email, double gpa)
    {
        Id = id;
        Name = name;
        Age = age;
        Email = email;
        GPA = gpa;
    }


    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Age: {Age}, " +
               $"Email: {Email}, GPA: {GPA}";
    }
}