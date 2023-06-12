using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace The_One_API.Services
{
  public class TwitterApiHelper
  {
    private readonly TwitterClient _twitterClient;

    public TwitterApiHelper(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret)
    {
      var credentials = new TwitterCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);
      _twitterClient = new TwitterClient(credentials);
    }

    public async Task<ITweet> PostTweet(string message)
    {
      return await _twitterClient.Tweets.PublishTweetAsync(message);
    }

    public async Task<IUser> GetUser(string username)
    {
      return await _twitterClient.Users.GetUserAsync(username);
    }

    public async Task FollowUser(string username)
    {
      await _twitterClient.Users.FollowUserAsync(username);
    }

    public async Task UnfollowUser(string username)
    {
      await _twitterClient.Users.UnfollowUserAsync(username);
    }
  }
}