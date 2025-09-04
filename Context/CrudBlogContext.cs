using Crud_Blog.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Crud_Blog.Context;

public class CrudBlogContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    public CrudBlogContext(DbContextOptions<CrudBlogContext> options) : base(options)
    {
        
    }
    public DbSet<Post> Post { get; set; }
    public DbSet<Comment> Comment { get; set; }
}