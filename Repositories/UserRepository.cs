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


        public async Task<User> CreateUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
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
        
        public async Task<User> UpdateUser(Guid id, User user)
        {
            var existingUser = await _context.User.FindAsync(id);
            if (existingUser == null)
                throw new KeyNotFoundException($"User with id {id} not found");

            existingUser.Name = user.Name;
            existingUser.Image = user.Image;

            _context.User.Update(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }
        
        public async Task<User> DeleteUser(Guid id)
        {
            var existingUser = await _context.User.FindAsync(id);
            if (existingUser == null)
                throw new KeyNotFoundException($"User with id {id} not found");
            _context.User.Remove(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }
        
        
        
        
        
    }
}