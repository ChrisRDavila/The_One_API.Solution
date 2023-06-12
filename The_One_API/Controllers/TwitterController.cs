using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ProjectName.Models;
using System.Collections.Generic;
using System.Linq;


namespace The_One_API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TwitterController : ControllerBase
  {
    private readonly TwitterContext _db;

    public TwitterController(TwitterContext db)
    {
      _db = db;
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
  }
}