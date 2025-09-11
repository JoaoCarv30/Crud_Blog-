using AutoMapper;
using Crud_Blog.Dtos;
using Crud_Blog.Entities;
using Crud_Blog.Services;
using Microsoft.AspNetCore.Mvc;
namespace Crud_Blog.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly IMapper _mapper;
    public UserController(UserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserDto userDto)
    {
        var user = _mapper.Map<User>(userDto);
        await _userService.CreateUser(user);
        return Ok(userDto);
    }

    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAllUsers()
    {
        var allUsers = await _userService.GetAllUsers(); 
        var userDtos = _mapper.Map<List<UserDto>>(allUsers);
        return Ok(userDtos);
    }
    
    [HttpGet("Basic")]
    public async Task<ActionResult<List<UserBasicDto>>> GetAllBasicUsers()
    {
        var allUsers = await _userService.GetAllUsers(); 
        var userDtos = _mapper.Map<List<UserBasicDto>>(allUsers);
        return Ok(userDtos);
    }

    
    [HttpGet("AllInformations")]
    public async Task<ActionResult<List<UserDto>>>GetAllUsersInformations()
    {
        var AllUsers = await _userService.GetAllUsersWithAllInformations(); 
       var UserListDto = _mapper.Map<List<UserDto>>(AllUsers);
        return Ok(UserListDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserBasicDto>> GetUserById(Guid id)
    {
      var user = await _userService.GetUserById(id);
      var userDto = _mapper.Map<UserBasicDto>(user);
      return Ok(userDto);
    }
    
    [HttpGet("Detail/{id}")]
    public async Task<ActionResult<UserDto>> GetUserByIdDetails(Guid id)
    {
        var user = await _userService.GetUserByIdDetails(id);
        var userDto = _mapper.Map<UserDto>(user);
        if (user == null)
            return NotFound("No user found");
        return Ok(userDto);
    }

    
    [HttpPut("{id}")]
    public async Task<ActionResult<UserDto>> UpdateUser(Guid id, UpdateUserDto dto)
    {
        var user = await _userService.GetUserById(id);
        if (user == null)
            return NotFound("User not found");

        _mapper.Map(dto, user); 

        var updatedUser = await _userService.UpdateUser(user);
        var updatedDto = _mapper.Map<UserDto>(updatedUser);

        return Ok(updatedDto);
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
