using Crud_Blog.Context;
using Crud_Blog.Entities;
using Crud_Blog.Generics;
using Crud_Blog.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Crud_Blog.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        
        private readonly CrudBlogContext _context;
        
        public CommentRepository(CrudBlogContext context) : base(context)
        {
            _context = context;
        }
        
    }
}