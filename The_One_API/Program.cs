using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using The_One_API.Models;
using The_One_API.Controllers;
using The_One_API.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Tweetinvi.Parameters;
using Microsoft.AspNetCore.Mvc;
using Tweetinvi;
using Tweetinvi.Models;




namespace The_One_API
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json");

      var configuration = builder.Build();

      string consumerKey = configuration["Twitter:ConsumerKey"];
      string consumerSecret = configuration["Twitter:ConsumerSecret"];
      string accessToken = configuration["Twitter:AccessToken"];
      string accessSecret = configuration["Twitter:AccessSecret"];

      var quotesHelper = new QuotesHelper(new System.Net.Http.HttpClient());
      var twitterApiHelper = new TwitterApiHelper(consumerKey, consumerSecret, accessToken, accessSecret, new System.Net.Http.HttpClient());
      var characterQuote = new CharacterQuote();

      var connectionString = configuration["ConnectionStrings:DefaultConnection"];

      var dbContextOptionsBuilder = new DbContextOptionsBuilder<The_One_APIContext>()
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

      var dbContext = new The_One_APIContext(dbContextOptionsBuilder.Options);

      // var controller = new TweetsController(dbContext, twitterApiHelper, characterQuote);
      string message = "This is Gandalf!";
      ITweet tweet = await twitterApiHelper.PostTweet(message);

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
    }
  }
}
