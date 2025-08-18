using Crud_Blog.Context;
using Crud_Blog.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_Blog.Controllers;

[Route("[controller]")]
[ApiController]

public class PostController : ControllerBase
{
    
    private readonly CrudBlogContext _context;

    public PostController(CrudBlogContext context)
    {
        _context = context;
    }



    [HttpPost]
    public async Task<IActionResult> CreatePost(Post? post)
    {
        if(post == null) return BadRequest("Post cannot be null");
        _context.Add(post);
        await _context.SaveChangesAsync();
        return Ok(post);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPosts()
    {
        var posts = await _context.Post.Include(c => c.Comment).ToListAsync();
        if (!posts.Any())
            return NotFound("No posts found");
        
        return Ok(posts);
    }
    
    [HttpGet ("{id}")]
    public async Task<IActionResult> GetPostById(Guid id){ 
        var post = await _context.Post.FindAsync(id);
        if (post == null)
            return NotFound("No post found");
        return Ok(post);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePost(Guid id, Post? post)
    {
        var findedPost = await _context.Post.FindAsync(id);
        if (findedPost == null)
            return NotFound("No post found"); 
        if (post == null)
            return BadRequest("Post cannot be null");
        findedPost.Title = post.Title;
        findedPost.Description = post.Description;
        findedPost.Image = post.Image;
        findedPost.UserId = post.UserId;
        _context.Post.Update(findedPost);
        await _context.SaveChangesAsync();
        return Ok(findedPost);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(Guid id)
    {
        var post = await _context.Post.FindAsync(id);
        if (post == null)
            return NotFound("No post found");
        _context.Post.Remove(post);
        await _context.SaveChangesAsync();
        return Ok("Post deleted successfully");
    }
}