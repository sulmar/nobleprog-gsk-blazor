using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public partial class Customer : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Account { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
