using Crud_Blog.Context;
using Crud_Blog.Entities;
using Crud_Blog.Repositories;

namespace Crud_Blog.Services
{
    public class PostService
    {
        private readonly PostRepository _postRepository;
        
        public PostService(PostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        
        
        public async Task<Post> CreatePost(Post post)
        {
            return await _postRepository.CretePost(post);
        }
        
        public async Task<List<Post>> GetAllPosts()
        {
            return await _postRepository.GetAllPosts();
        }

        public async Task<Post> GetPost(Guid id)
        {
            return await _postRepository.GetPostById(id);
        }
        
        public async Task<Post> UpdatePost(Guid id, Post post)
        {
            return await _postRepository.UpdatePost(id, post);
        }   
        
        public async Task<string> DeletePost(Guid id)
        {
            return await _postRepository.DeletePost(id);
        }
        
    }
}