using System;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;
using The_One_API.Services;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;


namespace The_One_API
{
  class Program
  {
    static async Task Main(string[] args)
    {
      
    
      var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

      var configuration = builder.Build();

      string consumerKey = configuration["TwitterAPI:ConsumerKey"];
      string consumerSecret = configuration["TwitterAPI:ConsumerSecret"];
      string accessToken = configuration["TwitterAPI:AccessToken"];
      string accessSecret = configuration["TwitterAPI:AccessSecret"];

      var httpClient = new HttpClient();
      httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessSecret}");

      string tweet = "This is Gandalf!";

      var tweetParameter = new
      {
        status = tweet
      };

      var jsonTweet = JsonConvert.SerializeObject(tweetParameter);
      var httpContent = new StringContent(jsonTweet, Encoding.UTF8, "application/json");

      string apiUrl = "https://api.twitter.com/2/tweets";

      var response = await httpClient.PostAsync(apiUrl, httpContent);
      string responseContent = await response.Content.ReadAsStringAsync();

      if (response.IsSuccessStatusCode)
      {
        Console.WriteLine("Tweet posted successfully.");
      }
      else
      {
        Console.WriteLine("Tweet failed to post.");
        Console.WriteLine(responseContent);
      }
    }
  }
}


    // var httpClient = new HttpClient();

    //   Console.WriteLine("Tweet posted successfully.");

    //   Console.ReadLine();
      // string theOneApiKey = configuration["EnvironmentVariables:TheOneApiKey"];
      // string gandalfCharId = configuration["EnvironmentVariables:GandalfCharId"];
      // string username = configuration["EnvironmentVariables:Username"];



      // var quotesHelper = new QuotesHelper(new System.Net.Http.HttpClient());
      // var twitterApiHelper = new TwitterApiHelper(consumerKey, consumerSecret, accessToken, accessSecret);
      // var characterQuote = new CharacterQuote();

      // var connectionString = configuration["ConnectionStrings:DefaultConnection"];

      // var dbContextOptionsBuilder = new DbContextOptionsBuilder<The_One_APIContext>()
      //   .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

      // var dbContext = new The_One_APIContext(dbContextOptionsBuilder.Options);

      // var controller = new TweetsController(dbContext, twitterApiHelper, characterQuote);
      // string message = "This is Gandalf!";
      // ITweet tweet = await twitterApiHelper.PostTweet(message);

      // Console.WriteLine(tweet);

      // controller.PostQuote();

      // while (true)
      // {
      //   try
      //   {
      //     await controller.PostQuote();
      //   }
      //   catch (Exception ex)
      //   {
      //     Console.WriteLine(ex.Message);
      //     break;
      //   }
      //   await Task.Delay(TimeSpan.FromMinutes(10));
      // }
