using AutoMapper;
using Crud_Blog.Dtos.Posts;
using Crud_Blog.Entities;
using Crud_Blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Blog.Controllers;

[Route("[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly PostService _postService;
    private readonly IMapper _mapper;
    public PostController(PostService postService, IMapper mapper)
    {
        _postService = postService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(PostsDto? post)
    {
        var entityPost = _mapper.Map<Post>(post);
        await _postService.CreatePost(entityPost);
        return Ok(post);
    }

    [HttpGet]
    public async Task<ActionResult<List<PostsBasicDto>>> GetAllPosts()
    {
        var AllPosts = await _postService.GetAllPosts();
        var PostListDto = _mapper.Map<List<PostsBasicDto>>(AllPosts);
        return Ok(PostListDto);
    }
    
    [HttpGet("AllInformations")]
    public async Task<ActionResult<List<PostsDto>>> GetAllPostsWithInformations()
    {
        var AllPosts = await _postService.GetAllPostsWithDetails();
        var AllPostsDto =  _mapper.Map<List<PostsDto>>(AllPosts);
        return Ok(AllPostsDto);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<PostsBasicDto>> GetPostById(Guid id)
    {
        var post = await _postService.GetPost(id);
        var postDto = _mapper.Map<PostsBasicDto>(post);
        return Ok(postDto);
    }
    
    [HttpGet("Details/{id}")]
    public async Task<ActionResult<PostsDto>> GetDetailsPostById(Guid id)
    {
        var post = await _postService.GetDetailsPost(id);
        var postDto = _mapper.Map<PostsDto>(post);
        return Ok(postDto);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<PostsBasicDto>> UpdatePost(Guid id, [FromBody] PostsBasicDto post)
    {
        var postById = await _postService.GetPost(id);
        if (postById == null)
            return NotFound("No post found for this id"); 
        postById.Title = post.Title;
        postById.Description = post.Description;
        var updatedPost = await _postService.UpdatePost(id, postById);
        var updatedPostDto = _mapper.Map<PostsBasicDto>(updatedPost);
        return Ok(updatedPostDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(Guid id)
    {
        var result = await _postService.DeletePost(id);
        return Ok(result);
    }
}