using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Crud_Blog.Entities;

public class User : IdentityUser<Guid>
{
    [Required]
    public string Name { get; set; }
    public string? Image { get; set; }
    public ICollection<Post>? Posts { get; set; }
}