using Crud_Blog.Dtos.Comments;
using Crud_Blog.Entities;

namespace Crud_Blog.Dtos.Posts
{
    public class PostsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Guid UserId { get; set; }
        public ICollection<CommentsDto>? Comment { get; set; }
        public UserBasicDto? User { get; set; }
    }
}