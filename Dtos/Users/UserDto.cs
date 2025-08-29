using Crud_Blog.Entities;
using System.ComponentModel.DataAnnotations;

namespace Crud_Blog.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}