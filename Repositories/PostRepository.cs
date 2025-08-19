using Crud_Blog.Context;
using Crud_Blog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crud_Blog.Repositories
{
    public class PostRepository
    {
        private readonly CrudBlogContext _context;
        
        public PostRepository(CrudBlogContext context)
        {
            _context = context;
        }
        
        public async Task<Post> CretePost(Post post)
        { 
            _context.Add(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<List<Post>> GetAllPosts()
        {
            var posts = await _context.Post.Include(c => c.Comment)
                .Include(u => u.User)
                .ToListAsync();
            
            return posts;
        }

        public async Task<Post> GetPostById(Guid id)
        {
            var post = await _context.Post
                .Include(c => c.Comment)
                .Include(u => u.User)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (post == null)
                throw new KeyNotFoundException($"User with id {id} not found");
            return post;
        }

        public async Task<Post> UpdatePost(Guid id, Post post)
        {
            var existingPost = await _context.Post.FindAsync(id); 
            if (existingPost == null)
                throw new KeyNotFoundException($"Post with id {id} not found");   
            
            existingPost.Title = post.Title; 
            existingPost.Description = post.Description; 
            existingPost.Image = post.Image; 
            
            return existingPost;
        }
        
        public async Task<String> DeletePost(Guid id)
        {
            var existingPost = await _context.Post.FindAsync(id); 
            if (existingPost == null)
                throw new KeyNotFoundException($"Post with id {id} not found");   
            _context.Post.Remove(existingPost);
            
            return "Post deleted successfully";
        }
        
        
    }
}