using Crud_Blog.Context;
using Crud_Blog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crud_Blog.Repositories
{
    public class CommentRepository
    {
        
        private readonly CrudBlogContext _context;
        
        public CommentRepository(CrudBlogContext context)
        {
            _context = context;
        }
        
        
        public async Task<Comment> CreateComment(Comment comment)
        {
            _context.Add(comment);
            await _context.SaveChangesAsync();
            return comment;
        }
        
        public async Task<List<Comment>> GetAllComments()
        {
            return await _context.Comment.ToListAsync();
        }

        public async Task<Comment> GetCommentById(Guid id)
        {
            var comment = await _context.Comment.FindAsync(id);
            if (comment == null)
                throw new KeyNotFoundException($"Comment with id {id} not found");
            return comment;
        }

        public async Task<Comment> UpdateComment(Guid id, Comment comment)
        {
            var commentById = await _context.Comment.FindAsync(id);
            if (commentById == null) 
                throw new KeyNotFoundException($"Comment with id {id} not found");
            commentById.Description = comment.Description;
            _context.Comment.Update(commentById); 
            await _context.SaveChangesAsync();
            return commentById;
        }
        
        public async Task<string> DeleteCommentById(Guid id)
        {
            var comment = await _context.Comment.FindAsync(id);
            if (comment == null)
                throw new KeyNotFoundException($"Comment with id {id} not found");
            _context.Comment.Remove(comment);
            _context.SaveChanges(); 
            return "Comment deleted successfully"; 
        }
        
    }
}