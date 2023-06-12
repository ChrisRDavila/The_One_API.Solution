using System.Threading.Tasks;
using System;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;

namespace The_One_API.Services
{
  class QuotesHelper
  {
    public static async Task<string> GetAllGandalfQuotes(string TheOneApiKey)
    {
      RestClient client = new RestClient($"https://the-one-api.dev/v2/");
      RestRequest request = new RestRequest($"character/{GandalfCharId}/quote");
      request.AddHeader("Authorization", $"Bearer {TheOneApiKey}");
      // client.AddDefaultHeader("Authorization", string.Format("Bearer {0}",TheOneApiKey));
      RestResponse response = await client.GetAsync(request);
      return response.dialogue;
    }

    public static async Task<string> GetRandomQuote(string TheOneApiKey)
    {
      string QuoteId = RandomNumberGenerator.GenerateRandomNumber();

      Random random = new Random();
      

      RestClient client = new RestClient($"https://the-one-api.dev/v2/");
      RestRequest request = new RestRequest($"character/{GandalfCharId}/quote");
      request.AddHeader("Authorization", $"Bearer {TheOneApiKey}");
      RestResponse response = await client.GetAsync(request);

      int index = random.Next(response.Count);

      return response.dialogue[index];
    }
  }

  public class RandomNumberGenerator
  {
    private static Random random = new Random();

    public static int GenerateRandomNumber()
    {
      return random.Next(1, 217);
    }
  }
}