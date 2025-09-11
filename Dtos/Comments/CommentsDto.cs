namespace Crud_Blog.Dtos.Comments
{
    public class CommentsDto
    {
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        
        public Guid PostId { get; set; }
        public string Description { get; set; }

        public UserBasicDto? User { get; set; }
    }
}   