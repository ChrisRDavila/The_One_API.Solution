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
  }
}