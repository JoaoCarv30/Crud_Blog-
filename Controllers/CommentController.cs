using Crud_Blog.Context;
using Crud_Blog.Entities;
using Crud_Blog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_Blog.Controllers;

[Route("[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly CommentService _commentService;
    public CommentController(CommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment(Comment? comment)
    {
        await _commentService.CreateComment(comment); 
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllComents()
    {
      var Comments =  await _commentService.GetAllComments(); 
      return Ok(Comments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCommentById(Guid id)
    {
        var Comment =  await _commentService.GetCommentById(id); 
        return Ok(Comment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Comment? dto)
    {
        var Comment =  await _commentService.GetCommentById(id); 
        if (Comment == null)
            return NotFound("No comment found for this post"); 
        Comment.Description = dto.Description;
        var updatedComment = await _commentService.UpdateComment(id, Comment);
        return Ok(updatedComment);
    } 

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var Comment =  await _commentService.GetCommentById(id); 
        if (Comment == null)
            return NotFound("No comment found for this post"); 
        await _commentService.DeleteComment(id);
        return NoContent();
    }
} 