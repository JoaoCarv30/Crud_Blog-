using Crud_Blog.Entities;

namespace Crud_Blog.Repositories.Interfaces
{
public interface IPostRepository : IBaseRepository<Post>
{
    Task<List<Post>> GetAllPostsWithDetails();
    Task<Post> GetDetailsPost(Guid id);
}
}