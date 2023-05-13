using BackEnd.Parseur;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using BackEnd;
using BackEnd.Model;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Python.Runtime;
using System.Diagnostics;


namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors]
    public class scraping : Controller
    {
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserTag userTag)
        {
            System.Console.WriteLine($"Nom: {userTag.usertag}");
            if (userTag.usertag != "")
            {
                Scrapeur scrapeur = new Scrapeur(userTag.usertag);
                scrapeur.getTweets(20);

                string json = System.IO.File.ReadAllText("tweets.json");
                List<string> insult_total = new List<string>();
                string[] tweets = JsonSerializer.Deserialize<string[]>(json);
                if (tweets.Length > 0 || tweets == null)
                {

                    int moyenne = 0;
                    foreach (string str in tweets)
                    {
                        ParsingTweet test = new ParsingTweet(str);
                        List<string> insults = test.getInsulteInTweet();
                        int toxicity = test.ToxicityTweet();
                        moyenne += toxicity;
                        Console.WriteLine(toxicity.ToString());
                        Console.WriteLine("tweet : " + str);
                        foreach (string insult in insults)
                        {
                            insult_total.Add(insult);

                        }
                    }
                    moyenne = moyenne / tweets.Length;
                    Console.WriteLine("moyenne : " + moyenne);
                    return Ok(new { toxicityMoyenne = moyenne, tweets = tweets, insult_moyenne = insult_total }) ;

                }
                else
                {
                    return BadRequest( new { message = "utilisateur non trouvé"});
                }
            }
            else { return BadRequest(); }
        }
    }

    public class UserTag { 
        public string? usertag { get; set; }
    }
}
