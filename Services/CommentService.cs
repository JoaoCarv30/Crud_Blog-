using Crud_Blog.Entities;
using Crud_Blog.Repositories;

namespace Crud_Blog.Services
{
    public class CommentService
    {
        private readonly CommentRepository _commentRepository; 
        private readonly IGenericRepository<Comment> _genericRepository;
        public CommentService(CommentRepository commentRepository, IGenericRepository<Comment> genericRepository)
        {
            _commentRepository = commentRepository;
            _genericRepository = genericRepository;
        }

        public async Task<Comment> CreateComment(Comment comment)
        {
            return await _genericRepository.Create(comment);
        }
        
        public async Task<List<Comment>> GetAllComments()
        {
            return await _genericRepository.GetAll();
        }

        public async Task<Comment> GetCommentById(Guid id)
        {
            return await _genericRepository.GetById(id);
        } 
        
        public async Task<Comment> UpdateComment(Guid id, Comment comment)
        {
            return await _genericRepository.Update(id, comment);
        }
        
        public async Task<bool> DeleteComment(Guid id)
        {
            return await _genericRepository.Delete(id);
        }
    }
}