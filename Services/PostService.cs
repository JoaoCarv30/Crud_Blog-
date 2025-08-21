using Crud_Blog.Context;
using Crud_Blog.Entities;
using Crud_Blog.Repositories;

namespace Crud_Blog.Services
{
    public class PostService
    {
        private readonly PostRepository _postRepository;
        private readonly IGenericRepository<Post> _genericRepository;
        public PostService(PostRepository postRepository, IGenericRepository<Post> genericRepository)
        {
            _postRepository = postRepository;
            _genericRepository = genericRepository;
        }
        
        
        public async Task<Post> CreatePost(Post post)
        {
            return await _genericRepository.Create(post);
        }
        
        public async Task<List<Post>> GetAllPosts()
        {
            return await _genericRepository.GetAll();
        }
        
        public async Task<List<Post>> GetAllPostsWithDetails()
        {
            return await _postRepository.GetAllPosts();
        }

        public async Task<Post> GetPost(Guid id)
        {
            return await _postRepository.GetPostById(id);
        }
        
        public async Task<Post> UpdatePost(Guid id, Post post)
        {
            return await _genericRepository.Update(id, post);
        }   
        
        public async Task<bool> DeletePost(Guid id)
        {
            return await _genericRepository.Delete(id);
        }
        
    }
}