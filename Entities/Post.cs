using System.ComponentModel.DataAnnotations;

namespace Crud_Blog.Entities;

public class Post : Entity
{
    [Required]
    public string Title { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Image { get; set; }
    [Required]
    public Guid UserId { get; set; }
    
    public ICollection<Comment>? Comment { get; set; }
    
    public User? User { get; set; }
}