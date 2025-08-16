using System.ComponentModel.DataAnnotations;

namespace Crud_Blog.Entities;

public class Comment : Entity
{
    [Required]
    public string Description { get; set; }
    
    [Required]
    public Guid PostId { get; set; }
    [Required]
    public Guid UserId { get; set; }
    
}