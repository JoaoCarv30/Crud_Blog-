namespace Crud_Blog.Dtos.Comments
{
    public class CommentsDto
    {
        public string Description { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
    }
}