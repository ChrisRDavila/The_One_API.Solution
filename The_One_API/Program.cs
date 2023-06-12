using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using The_One_API.Models;
using The_One_API.Controllers;
using The_One_API.Helpers;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;



namespace The_One_API
{
  class Program
  {
    static void Main(string[] args)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json");

      var configuration = builder.Build();

      string consumerKey = configuration["Twitter:ConsumerKey"];
      string consumerSecret = configuration["Twitter:ConsumerSecret"];
      string accessToken = configuration["Twitter:AccessToken"];
      string accessTokenSecret = configuration["Twitter:AccessTokenSecret"];

      var qoutesHelper = new QoutesHelper(new System.Net.Http.HttpClient());
      var twitterApiHelper = new TwitterApiHelper(consumerKey, consumerSecret, accessToken, accessTokenSecret);

      var controller = new TwitterController(qoutesHelper, twitterApiHelper);

      await controller.PostQoute();

      while (true)
      {
        await controller.PostQoute();
        await Task.Delay(TimeSpan.FromMinutes(10));
      }
    }
  }
}
