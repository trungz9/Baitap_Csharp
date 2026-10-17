using System.ComponentModel.DataAnnotations;

namespace WinFormsApp2.data.entity;

public class ClassModel
{
    [Required]
    [RegularExpression("^CSE\\d{4}$", ErrorMessage = "Code must be in format CSENNNN")]
    public string Code { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    public List<Student> Students { get; set; } = new();
}
