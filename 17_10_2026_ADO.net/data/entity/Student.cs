using System.ComponentModel.DataAnnotations;

namespace WinFormsApp2.data.entity;

public class Student
{
    [Required]
    [RegularExpression("^[A-Za-z0-9]{1,20}$")]
    public string StudentId { get; set; } = string.Empty;

    [Required]
    [StringLength(100, MinimumLength = 2)]
    public string FullName { get; set; } = string.Empty;

    [EmailAddress]
    [StringLength(254)]
    public string Email { get; set; } = string.Empty;

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Phone]
    [StringLength(30)]
    public string Phone { get; set; } = string.Empty;

    [Range(0, 10)]
    public double Score { get; set; }

    [StringLength(50)]
    public string Status { get; set; } = string.Empty;

    public ClassModel? Class { get; set; }
}
