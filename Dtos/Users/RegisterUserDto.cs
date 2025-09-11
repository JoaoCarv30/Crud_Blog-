namespace Crud_Blog.Dtos
{
    public class RegisterUserDto
    {
        public string UserName { get; set; } 
        public string Name { get; set; } 
        public string Email { get; set; } 
        public string? Image { get; set; } 
        public string Password { get; set; } 
    }
}