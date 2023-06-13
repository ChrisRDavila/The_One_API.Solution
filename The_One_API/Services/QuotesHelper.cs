using System.Threading.Tasks;
using System;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace The_One_API.Services
{
  public class QuotesHelper
  {
    private readonly HttpClient _httpClient;

    public QuotesHelper(HttpClient httpClient)
    {
      _httpClient = httpClient;
    }
    public static async Task<string> GetAllCharQuotes(string apiKey, string characterId)
    {
      RestClient client = new RestClient($"https://the-one-api.dev/v2/");
      RestRequest request = new RestRequest($"character/{characterId}/quote");
      request.AddHeader("Authorization", $"Bearer {apiKey}");

      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    // public static async Task<string> GetRandomQuote(string apiKey, string characterId)
    // {
    //   RestClient client = new RestClient($"https://the-one-api.dev/v2/");
    //   RestRequest request = new RestRequest($"character/{characterId}/quote");
    //   request.AddHeader("Authorization", $"Bearer {apiKey}");

    //   RestResponse response = await client.GetAsync(request);
    //   List<string> quotes = JsonConvert.DeserializeObject<List<string>>(response.Content);

    //   if (quotes.Count == 0)
    //   {
    //     return "No quotes available.";
    //   }

    //   Random random = new Random();
    //   int randomIndex = random.Next(quotes.Count);
    //   string RandomQuote = quotes[randomIndex];

    //   return RandomQuote;
    // }
  }

  // public class RandomNumberGenerator
  // {
  //   private static Random random = new Random();

  //   public static int GenerateRandomNumber()
  //   {
  //     return random.Next(1, 217);
  //   }
  // }
}