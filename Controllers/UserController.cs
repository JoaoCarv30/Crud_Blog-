using Crud_Blog.Context;
using Crud_Blog.Entities;
using Crud_Blog.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Crud_Blog.Controllers;


[Route("[controller]")]
[ApiController]

public class UserController : ControllerBase
{

    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(User user)
    {
        await _userService.CreateUser(user);
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var AllUsers = await _userService.GetAllUsers(); 
        return Ok(AllUsers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
      var user = await _userService.GetUserById(id);
      if (user == null)
          return NotFound("No user found");
      return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, User dto)
    {
        var user = await _userService.GetUserById(id); 
        if (user == null)
            return NotFound("No user found"); 
        user.Name = dto.Name; 
        user.Image = dto.Image; 
        var updatedUser = await _userService.UpdateUser(user);
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        var user = await _userService.DeleteUser(id);
        if (user == null)
            return NotFound("No user found");
        return Ok(user);
    } 
}
