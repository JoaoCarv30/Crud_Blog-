using System.Linq.Expressions;

namespace Crud_Blog.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Create(T entity);
        Task<List<T>> GetAll();
        Task<T?> GetById(Guid id);
        Task<T?> Update(Guid id, T entity);
        Task<bool> Delete(Guid id);
        Task<bool> GetByExpression(Expression<Func<T, bool>> expression);
    }
}