using Crud_Blog.Dtos.Posts;
using Crud_Blog.Entities;
using System.ComponentModel.DataAnnotations;

namespace Crud_Blog.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        
        public string Email { get; set; }
        public ICollection<PostsDto>? Posts { get; set; }
    }
}