using Crud_Blog.Context;
using Crud_Blog.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_Blog.Controllers;


[Route("[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    
    private readonly CrudBlogContext _context;

    public UserController(CrudBlogContext context)
    {
        _context = context;
    }



    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        
        if (user == null)
        {
            return BadRequest("User cannot be null");
        }
        
        _context.User.Add(user);
        await _context.SaveChangesAsync();
        return Ok(user);

    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _context.User
            .Include(u => u.Posts)!                  
            .ThenInclude(p => p.Comment)           
            .ToListAsync();

        if (!users.Any())
            return NotFound("No users found");

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _context.User
            .Include(u => u.Posts)!
            .ThenInclude(p => p.Comment)
            .FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            return NotFound($"User with id {id} not found");

        return Ok(user);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, User dto)
    {
        var user =  await _context.User.FindAsync(id);
        if (user == null)
            return NotFound("No user found");
        user.Name = dto.Name;
        user.Image = dto.Image;
        user.UpdatedAt = DateTime.UtcNow;
        _context.User.Update(user);
        await _context.SaveChangesAsync();
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var user =  await _context.User.FindAsync(id);
        if (user == null)
            return NotFound("No user found");
        _context.User.Remove(user);
        await _context.SaveChangesAsync();
        return Ok("User deleted successfully");
    }




}