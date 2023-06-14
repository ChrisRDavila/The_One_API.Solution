using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;



namespace The_One_API.Services
{
  public class TwitterApiHelper
  {
    private readonly HttpClient _httpClient;
    
    public TwitterApiHelper(HttpClient httpClient)
  {
      _httpClient = httpClient;
  }
      // _ = HandleMentions();


    // public static ITwitterCredentials GenerateCredentials()
    // {
    //   return new TwitterCredentials("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");
    // }

    // public static ITwitterCredentials GenerateAppCreds()
    // {
    //   var userCreds = GenerateCredentials();
    //   return new TwitterCredentials(userCreds.ConsumerKey, userCreds.ConsumerSecret);
    // }
    public async Task PostTweet(string quote, string bearerToken, string consumerKey, string consumerSecret, string accessToken, string accessSecret)
    {
      string apiUrl = "https://api.twitter.com/2/statuses/update.json";
      
      HttpClient httpClient = new HttpClient();

      _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);

      var requestBody = new
      {
        status = quote
      };

      var json = JsonConvert.SerializeObject(requestBody);
      var content = new StringContent(json, Encoding.UTF8, "application/json");

      var response = await _httpClient.PostAsync(apiUrl, content);

      if (response.IsSuccessStatusCode)
      {
        Console.WriteLine("Tweet posted successfully!");
      }
      else
      {
        Console.WriteLine("Error posting tweet!");
        var responseContent = await response.Content.ReadAsStringAsync();
        Console.WriteLine(responseContent);
      } 
      
    }
    
    //   if (quote.Length > 280)
    //   {
    //     quote = quote.Substring(0, 280 - 3) + "...";
    //   }

    //   return await _twitterClient.Tweets.PublishTweetAsync(new PublishTweetParameters(quote));
    // }

    // public async Task HandleMentions()
    // {
    //   var stream = _twitterClient.Streams.CreateFilteredStream();

    //   stream.AddTrack("@Gandalf_bot");

    //   var streamV2 = _twitterClient.StreamsV2.CreateFilteredStream();
    //   stream.MatchingTweetReceived += (sender, args) =>
    //   {
    //     var mention = args.Tweet;
    //     string username = mention.CreatedBy.ScreenName;
    //     string message = mention.FullText;

    //     string response = $"@{username} {message}";
        
    //     _twitterClient.Tweets.PublishTweetAsync(new PublishTweetParameters
    //     {
    //       InReplyToTweet = mention,
    //       Text = response
    //     });
    //   };

    //   await streamV2.StartAsync();
    // }

    // public async Task<IUser> GetUser(string username)
    // {
    //   return await _twitterClient.Users.GetUserAsync(username);
    // }

    // public async Task FollowUser(string username)
    // {
    //   await _twitterClient.Users.FollowUserAsync(username);
    // }

    // public async Task UnfollowUser(string username)
    // {
    //   await _twitterClient.Users.UnfollowUserAsync(username);
    // }
  }
}