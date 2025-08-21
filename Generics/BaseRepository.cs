using Crud_Blog.Context;
using Crud_Blog.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Crud_Blog.Generics
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly CrudBlogContext _context;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(CrudBlogContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        
        public async Task<T> Create(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> GetById(Guid id)
        {
            var entity = await _dbSet.FindAsync(id); 
            if(entity == null)
                throw new KeyNotFoundException($"Entity with id {id} not found");
            return entity;
        }

        public async Task<List<T>> GetAll()
        {
           return  await _dbSet.ToListAsync();
        }

        public async Task<T?> Update(Guid id, T entity)
        {
            var existingEntity = await _dbSet.FindAsync(id);
            if (existingEntity == null)
                throw new KeyNotFoundException($"Entity with id {id} not found");

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return existingEntity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var existingEntity = await _dbSet.FindAsync(id);
            if (existingEntity == null)
                throw new KeyNotFoundException($"Entity with id {id} not found");
            _dbSet.Remove(existingEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> GetByExpression(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        } 
        
    }
}