using Crud_Blog.Entities;
using Crud_Blog.Repositories.Interfaces;

namespace Crud_Blog.Services
{
    public class CommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comment> CreateComment(Comment comment)
        {
            return await _commentRepository.Create(comment);
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await _commentRepository.GetAll();
        }

        public async Task<Comment> GetCommentById(Guid id)
        {
            return await _commentRepository.GetById(id);
        }

        public async Task<Comment> UpdateComment(Guid id, Comment comment)
        {
            return await _commentRepository.Update(id, comment);
        }

        public async Task<bool> DeleteComment(Guid id)
        {
            return await _commentRepository.Delete(id);
        }
        
    }
}