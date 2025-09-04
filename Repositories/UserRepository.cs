using Crud_Blog.Context;
using Crud_Blog.Entities;
using Crud_Blog.Generics;
using Crud_Blog.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crud_Blog.Repositories
{
public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly CrudBlogContext _context;

    public UserRepository(CrudBlogContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllUsersWithDetails()
    {
        return await _context.Users
            .Include(u => u.Posts)!
            .ThenInclude(p => p.Comment)
            .ToListAsync();
    }
        
    public async Task<User> GetUserDetails(Guid id)
    {
        var user = await _context.Users
            .Include(u => u.Posts)!
            .ThenInclude(p => p.Comment)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            throw new KeyNotFoundException($"User with id {id} not found");

        return user;
    }
}
}