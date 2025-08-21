using Crud_Blog.Context;
using Crud_Blog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crud_Blog.Repositories
{
    public class UserRepository
    {
        public readonly CrudBlogContext _context;
        
        public UserRepository(CrudBlogContext Context)
        {
         _context =  Context; 
        }

        public async Task<List<User>> GetAllUsers()
        {
           return await _context.User
                .Include(u => u.Posts)!
                .ThenInclude(p => p.Comment)
                .ToListAsync();
        }
        
        public async Task<User> GetUserById(Guid id)
        {
            var user = await _context.User
                .Include(u => u.Posts)!
                .ThenInclude(p => p.Comment)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
                throw new KeyNotFoundException($"User with id {id} not found");

            return user;
        }
    }
}