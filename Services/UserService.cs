using Crud_Blog.Entities;
using Crud_Blog.Repositories;

namespace Crud_Blog.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        
        public async Task<User> CreateUser(User user)
        {
            return await _userRepository.CreateUser(user);
        }
        
        public async Task<List<User>> GetAllUsers() 
        {
            return await _userRepository.GetAllUsers();
        }
        
        public async Task<User>  GetUserById(Guid id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _userRepository.UpdateUser(user.Id, user);
        }
        
        public async Task<User> DeleteUser(Guid id)
        {
            return await _userRepository.DeleteUser(id);
        }
       
    }
}