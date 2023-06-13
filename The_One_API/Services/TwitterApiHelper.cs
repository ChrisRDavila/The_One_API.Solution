using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace The_One_API.Services
{
  public class TwitterApiHelper
  {
    private readonly TwitterClient _twitterClient;
    private readonly HttpClient _httpClient;

    public TwitterApiHelper(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret, HttpClient httpClient)
    {
      var credentials = new TwitterCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);
      _twitterClient = new TwitterClient(credentials);
      _httpClient = httpClient;
    }


    public static ITwitterCredentials GenerateCredentials()
    {
      return new TwitterCredentials("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");
    }

    public static ITwitterCredentials GenerateAppCreds()
    {
      var userCreds = GenerateCredentials();
      return new TwitterCredentials(userCreds.ConsumerKey, userCreds.ConsumerSecret);
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