using Crud_Blog.Entities;
using Microsoft.EntityFrameworkCore;

namespace Crud_Blog.Context;

public class CrudBlogContext : DbContext
{
    public CrudBlogContext(DbContextOptions<CrudBlogContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> User { get; set; }
    public DbSet<Post> Post { get; set; }
    public DbSet<Comment> Comment { get; set; }
}