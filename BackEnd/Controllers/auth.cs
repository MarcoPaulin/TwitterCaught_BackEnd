using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class auth : Controller
    {
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto userDto)
        {
            System.Console.WriteLine($"Nom: {userDto.username}, Prénom: {userDto.password}, Prénom: {userDto.passwordConfirmation}, Prénom: {userDto.twitterArobase}");
            if ( userDto.username == "test") {
                return Ok(new {Message = "Utilisateur créé avec succès!"});
            }
            else { return BadRequest(); }
        }
    }

    public class UserDto
    {
        public string? username { get; set; }
        public string? password { get; set; }
        public string? passwordConfirmation { get; set; }
        public string? twitterArobase { get; set; }
    }
}
