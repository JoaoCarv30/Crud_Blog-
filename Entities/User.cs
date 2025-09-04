using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Crud_Blog.Entities;

public class User : IdentityUser<Guid>
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Image { get; set; }
    public ICollection<Post>? Posts { get; set; }
}