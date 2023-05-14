using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.IdentityModel.Tokens.Jwt;
using System;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class login : Controller
    {
        [HttpPost]
        public async Task<IActionResult> loginUser([FromBody] Userlogin Userlogin)
        {
            System.Console.WriteLine($"username: {Userlogin.username}, pass: {Userlogin.password}");
            try
            {
                string mysqlCon = "server=127.0.0.1; user=root ; database=twittercaught; password=";
                MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon);
                Console.WriteLine("ici");
                try
                {
                    mySqlConnection.Open();
                    Console.WriteLine("ok");
                    MySqlCommand mySqlCommandSecond = new MySqlCommand("select * from users", mySqlConnection);
                    MySqlDataReader reader = mySqlCommandSecond.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString("username"));
                        if (Userlogin.username.Equals(reader.GetString("username"))&& Userlogin.password.Equals(reader.GetString("password")))
                        {
                            var user = Userlogin.username;
                            Console.WriteLine("Connection OK");
                            Userlogin.token = CreateJwt(Userlogin);
                            return Ok(new {Token = Userlogin.token, Message = "Connection OK" });
                        }
                    }
                    return BadRequest("utilisateur non present");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                }
                finally { mySqlConnection.Close(); }
                return Ok(new { Message = "ok", token = Userlogin.token });
            }
            catch { return BadRequest(new { Message = "une erreur est survenue" }); }
        }
        private string CreateJwt(Userlogin user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret.....");
            var identity = new ClaimsIdentity(new Claim[] {
            new Claim(ClaimTypes.Name, $"{user.username}")
        });
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

    }

    public class Userlogin
    {
        public string? username { get; set; }
        public string? password { get; set; }
        public string? token { get; set; }
    }

    
}
