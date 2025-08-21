using Crud_Blog.Context;
using Crud_Blog.Entities;
using Crud_Blog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_Blog.Controllers;

[Route("[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly PostService _postService;

    public PostController(PostService postService)
    {
        _postService = postService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePost(Post? post)
    {
        await _postService.CreatePost(post);
        return Ok(post);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        var AllPosts = await _postService.GetAllPosts();
        return Ok(AllPosts);
    }
    
    [HttpGet("AllInformations")]
    public async Task<IActionResult> GetAllPostsWithInformations()
    {
        var AllPosts = await _postService.GetAllPostsWithDetails();
        return Ok(AllPosts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPostById(Guid id)
    {
        var post = await _postService.GetPost(id);
        return Ok(post);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(Guid id, Post? post)
    {
        await _postService.UpdatePost(id, post);
        return Ok(post);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(Guid id)
    {
        var result = await _postService.DeletePost(id);
        return Ok(result);
    }
}