using AutoMapper;
using Crud_Blog.Context;
using Crud_Blog.Dtos.Comments;
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
    private readonly IMapper _mapper;
    public CommentController(CommentService commentService, IMapper mapper)
    {
        _commentService = commentService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<ActionResult<CommentsDto>> CreateComment(CommentsDto? comment)
    {
        var entityComment = _mapper.Map<Comment>(comment);
        await _commentService.CreateComment(entityComment); 
        return Ok(comment);
    }

    [HttpGet]
    public async Task<ActionResult<List<CommentsDto>>> GetAllComents()
    {
      var Comments =  await _commentService.GetAllComments(); 
        var CommentsDto = _mapper.Map<List<CommentsDto>>(Comments);
      return Ok(CommentsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCommentById(Guid id)
    {
        var Comment =  await _commentService.GetCommentById(id); 
        return Ok(Comment);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CommentsBasicDto>> Update(Guid id, CommentsDto? comment)
    {
        var Comment =  await _commentService.GetCommentById(id); 
        if (Comment == null)
            return NotFound("No comment found for this post"); 
        Comment.Description = comment.Description;
        var updatedComment = await _commentService.UpdateComment(id, Comment);
        var updatedCommentDto =   _mapper.Map<CommentsBasicDto>(updatedComment);
        return Ok(updatedCommentDto);
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