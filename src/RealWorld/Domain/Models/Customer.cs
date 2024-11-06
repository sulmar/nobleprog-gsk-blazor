using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public partial class Customer : BaseEntity
{
    [Required, MinLength(3)]
    public string Name { get; set; }

    [MaxLength(10)]
    public string Description { get; set; }

    [RegularExpression(@"\d*", ErrorMessage = "Only digits")]
    public string Account { get; set; }

    public string Password { get; set; }

    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
}
