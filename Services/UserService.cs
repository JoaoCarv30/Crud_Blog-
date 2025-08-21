using Crud_Blog.Entities;
using Crud_Blog.Generics;
using Crud_Blog.Repositories;

namespace Crud_Blog.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        private readonly IGenericRepository<User> _userGenericRepository;
        
        public UserService(UserRepository userRepository, IGenericRepository<User> userGenericRepository)
        {
            _userRepository = userRepository;
            _userGenericRepository = userGenericRepository;
        }
        
        public async Task<User> CreateUser(User user)
        {
            return await _userGenericRepository.Create(user);
        }
        
        public async Task<List<User>> GetAllUsers() 
        {
            return await _userGenericRepository.GetAll();
        }
        
        public async Task<List<User>> GetAllUsersWithAllInformations() 
        {
            return await _userRepository.GetAllUsers();
        }
        
        public async Task<User> GetUserById(Guid id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _userGenericRepository.Update(user.Id, user);
        }
        
        public async Task<bool> DeleteUser(Guid id)
        {
            return await _userGenericRepository.Delete(id);
        }
       
    }
}