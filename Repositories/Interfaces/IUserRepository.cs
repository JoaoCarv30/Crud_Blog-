using Crud_Blog.Entities;

namespace Crud_Blog.Repositories.Interfaces
{
public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetUserDetails(Guid id);
    Task<List<User>> GetAllUsersWithDetails();
}
}