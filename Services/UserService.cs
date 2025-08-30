using Crud_Blog.Entities;
using Crud_Blog.Generics;
using Crud_Blog.Repositories;
using Crud_Blog.Repositories.Interfaces;

namespace Crud_Blog.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<User> CreateUser(User user)
        {
            return await _userRepository.Create(user);
        }
        
        public async Task<List<User>> GetAllUsers() 
        {
            return await _userRepository.GetAll();
        }
        
        public async Task<List<User>> GetAllUsersWithAllInformations() 
        {
            return await _userRepository.GetAllUsersWithDetails();
        }
        
        public async Task<User> GetUserById(Guid id)
        {
            return await _userRepository.GetById(id);
        }
        
        public async Task<User> GetUserByIdDetails(Guid id)
        {
            return await _userRepository.GetUserDetails(id);
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _userRepository.Update(user.Id, user);
        }
        
        public async Task<bool> DeleteUser(Guid id)
        {
            return await _userRepository.Delete(id);
        }
      
    }
}