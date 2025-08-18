using Crud_Blog.Context;
using Crud_Blog.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_Blog.Controllers;


[Route("[controller]")]
[ApiController]

public class CommentController : ControllerBase
{
    private readonly CrudBlogContext _context;

    public CommentController(CrudBlogContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateComment( Comment? comment)
    {
        if (comment == null) return BadRequest("Comment cannot be null");
        await _context.Comment.AddAsync(comment);
        await _context.SaveChangesAsync();
        return Ok (comment);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllComents()
    {
        var comments = await _context.Comment.ToListAsync();
        if (!comments.Any())
            return NotFound("No comments found");
        return Ok(comments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCommentById(Guid id)
    {
        var comment =  await _context.Comment.FindAsync(id);
        if (comment == null)
            return NotFound("No comment found for this post");
        return Ok(comment);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Comment? dto)
    {
        var comment = await _context.Comment.FindAsync(id);
        if (comment == null)
            return NotFound("No comment found for this post");
        comment.Description = dto.Description;
        return Ok(comment);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var comment = await _context.Comment.FindAsync(id);
        if (comment == null)
            return NotFound("No comment found for this post");
        return Ok(comment);
    }
    
}