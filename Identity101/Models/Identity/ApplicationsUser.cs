using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Identity101.Models.Identity;

public class ApplicationUser : IdentityUser
{
    [StringLength(50)]
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public DateTime RegisterDate { get; set; } = DateTime.UtcNow;

}