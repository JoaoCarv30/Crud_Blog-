using System.ComponentModel.DataAnnotations;

namespace Crud_Blog.Entities;

public class User : Entity
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Image { get; set; }
    public ICollection<Post>? Posts { get; set; }
}