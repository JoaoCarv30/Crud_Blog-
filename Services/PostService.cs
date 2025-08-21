using Crud_Blog.Context;
using Crud_Blog.Entities;
using Crud_Blog.Repositories;
using Crud_Blog.Repositories.Interfaces;

namespace Crud_Blog.Services
{
    public class PostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        
        public async Task<Post> CreatePost(Post post)
        {
            return await _postRepository.Create(post);
        }
        
        public async Task<List<Post>> GetAllPosts()
        {
            return await _postRepository.GetAll();
        }
        
        public async Task<List<Post>> GetAllPostsWithDetails()
        {
            return await _postRepository.GetAllPostsWithDetails();
        }
        
        public async Task<Post> GetPost(Guid id)
        {
            return await _postRepository.GetById(id);
        }

        public async Task<Post> GetDetailsPost(Guid id)
        {
            return await _postRepository.GetDetailsPost(id);
        }
        
        public async Task<Post> UpdatePost(Guid id, Post post)
        {
            return await _postRepository.Update(id, post);
        }   
        
        public async Task<bool> DeletePost(Guid id)
        {
            return await _postRepository.Delete(id);
        }
    }
}