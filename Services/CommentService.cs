using Crud_Blog.Entities;
using Crud_Blog.Repositories;

namespace Crud_Blog.Services
{
    public class CommentService
    {
        private readonly CommentRepository _commentRepository; 
        public CommentService(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comment> CreateComment(Comment comment)
        {
            return await _commentRepository.CreateComment(comment);
        }
        
        public async Task<List<Comment>> GetAllComments()
        {
            return await _commentRepository.GetAllComments();
        }

        public async Task<Comment> GetCommentById(Guid id)
        {
            return await _commentRepository.GetCommentById(id);
        } 
        
        public async Task<Comment> UpdateComment(Guid id, Comment comment)
        {
            return await _commentRepository.UpdateComment(id, comment);
        }
        
        public async Task<string> DeleteComment(Guid id)
        {
            return await _commentRepository.DeleteCommentById(id);
        }
    }
}