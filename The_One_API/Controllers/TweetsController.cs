using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using The_One_API.Models;
using The_One_API.Services;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace The_One_API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TweetsController : ControllerBase
  {
    private readonly The_One_APIContext _db;
    private readonly TwitterApiHelper _twitterApiHelper;
    private readonly QuotesHelper _quotesHelper;


    public TweetsController(The_One_APIContext db, TwitterApiHelper twitterApiHelper, QuotesHelper quotesHelper)
    {
      _db = db;
      _twitterApiHelper = twitterApiHelper;
      _quotesHelper = quotesHelper;
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

    internal Task Post()
    {
      throw new NotImplementedException();
    }
  }
}