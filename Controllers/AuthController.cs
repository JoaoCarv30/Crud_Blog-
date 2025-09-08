using AutoMapper;
using Crud_Blog.Dtos;
using Crud_Blog.Entities;
using Crud_Blog.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crud_Blog.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly IMapper _mapper;

        public AuthController(AuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterUserDto>> Register([FromBody] RegisterUserDto dto)
        {
              var User = _mapper.Map<User>(dto);
              var result = await _authService.RegisterUser(User, dto.Password);
              if(!result.Succeeded)   return BadRequest(result.Errors);
              return Ok(_mapper.Map<RegisterUserDto>(User));
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginDto>> Login([FromBody] LoginDto dto)
        {
            var token = await _authService.Login(dto.UserName, dto.Password);

            if (token == null)
                return Unauthorized("Invalid credentials");
            return Ok(new { token });
        }
     
        
    }
}