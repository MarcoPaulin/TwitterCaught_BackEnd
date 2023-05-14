using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Text.Json;

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
            System.Console.WriteLine($"username: {userDto.username}, pass: {userDto.password}, arobase: {userDto.twitterArobase}, email: {userDto.email}");
            try {
                string mysqlCon = "server=127.0.0.1; user=root ; database=twittercaught; password=";
                MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon);
                Console.WriteLine("ici");
                try
                {

                    Scrapeur scrapeur = new Scrapeur(userDto.twitterArobase);
                    scrapeur.getTweets(1);

                    string json = System.IO.File.ReadAllText("tweets.json");
                    List<string> insult_total = new List<string>();
                    string[] tweets = JsonSerializer.Deserialize<string[]>(json);
                    if (tweets == null || tweets.Length == 0)
                    {
                        return BadRequest(new { Message = "L'utilisateur n'existe pas ou votre compte est en privé" });
                    }
                    mySqlConnection.Open();
                    Console.WriteLine("ok");
                    MySqlCommand mySqlCommandSecond = new MySqlCommand("INSERT INTO users (email, password, username, twitterusername) VALUES ('"+ userDto.email + "', '"+ userDto.password + "' , '"+ userDto.username + "', '"+ userDto.twitterArobase + "');", mySqlConnection);
                    Console.WriteLine(mySqlCommandSecond);
                    int update = mySqlCommandSecond.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return (BadRequest(new { Message = "Erreur dans le scrapping" }));
                }
                finally { mySqlConnection.Close(); }
                Console.WriteLine("end");
                return Ok(new {Message = "Utilisateur créé avec succès!"});
            }
            catch { return BadRequest(); }
        }
    }

    public class UserDto
    {
        public string? username { get; set; }
        public string? password { get; set; }
        public string? twitterArobase { get; set; }
        public string? email { get; set; }
    }
}
