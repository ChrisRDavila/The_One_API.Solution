using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using The_One_API.Models;
using The_One_API.Services;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using The_One_API.Keys;

namespace The_One_API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TweetsController : ControllerBase
  {
    private readonly The_One_APIContext _db;
    private readonly TwitterApiHelper _twitterApiHelper;
    private readonly CharacterQuote _characterQuote;


    public TweetsController(The_One_APIContext db, TwitterApiHelper twitterApiHelper, CharacterQuote characterQuote)
    {
      _db = db;
      _twitterApiHelper = twitterApiHelper;
      _characterQuote = characterQuote;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Tweet>> Get()
    {
      return _db.Tweets.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Tweet> Get(int id)
    {
      return _db.Tweets.FirstOrDefault(entry => entry.TweetId == id);
    }

    [HttpPost]
    public void Post([FromBody] Tweet tweet)
    {
      _db.Tweets.Add(tweet);
      _db.SaveChanges();
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Tweet tweet)
    {
      tweet.TweetId = id;
      _db.Entry(tweet).State = EntityState.Modified;
      _db.SaveChanges();
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var tweetToDelete = _db.Tweets.FirstOrDefault(entry => entry.TweetId == id);
      _db.Tweets.Remove(tweetToDelete);
      _db.SaveChanges();
    }

    [HttpGet("post-quote")]
    public async Task<ActionResult> PostQuote()
    {
      try
      {
        string quote =_characterQuote.GetRandomGandalfQuote(EnvironmentVariables.TheOneApiKey, EnvironmentVariables.GandalfCharId);

        

        await _twitterApiHelper.PostTweet(quote);

        return Ok("Quote posted to Twitter successfully");
      }
      catch (Exception ex)
      {
        return BadRequest("An error occurred while trying to post quote to Twitter: " + ex.Message);
      }
    }

    internal Task Post()
    {
      throw new NotImplementedException();
    }
  }
}