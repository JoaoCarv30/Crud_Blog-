using Crud_Blog.Context;
using Crud_Blog.Entities;
using Crud_Blog.Generics;
using Crud_Blog.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crud_Blog.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly CrudBlogContext _context;
        
        public PostRepository(CrudBlogContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Post>> GetAllPostsWithDetails()
        {
            var posts = await _context.Post.Include(c => c.Comment)
                .Include(u => u.User)
                .ToListAsync();
            
            return posts;
        }

        public async Task<Post> GetDetailsPost(Guid id)
        {
            var post = await _context.Post
                .Include(c => c.Comment)
                .Include(u => u.User)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (post == null)
                throw new KeyNotFoundException($"User with id {id} not found");
            return post;
        }

    
        
        
    }
}