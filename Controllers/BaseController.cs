using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace Crud_Blog.Controllers
{

    public class BaseController : ControllerBase
    {
        
        
        public BaseController()
        {
            
        }
        
        
        public Guid GetUserId()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value;
            return Guid.Parse(userId);
        }
        
    }
}