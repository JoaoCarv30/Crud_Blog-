using Crud_Blog.Entities;

namespace Crud_Blog.Dtos.Posts
{
    public class PostsDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Guid UserId { get; set; }
        public ICollection<Comment>? Comment { get; set; }
        public User? User { get; set; }
    }
}