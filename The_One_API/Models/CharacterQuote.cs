using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using RestSharp;
using The_One_API.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace The_One_API.Models
{
  public class CharacterQuote
  {
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("dialog")]
    public string Dialog { get; set; }
    [JsonProperty("movie")]
    public string Movie { get; set; }
    [JsonProperty("character")]
    public string Character { get; set; }
  

    public List<CharacterQuote> GetGandalfQuotes(string apiKey, string gandalfCharId)
    {
      var apiCallTask = QuotesHelper.GetAllCharQuotes(apiKey, gandalfCharId);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);

      List<CharacterQuote> characterQuoteList = JsonConvert.DeserializeObject<List<CharacterQuote>>(jsonResponse["docs"].ToString());

      // foreach (CharacterQuote item in characterQuoteList)
      // {
      //   Console.WriteLine(item.Dialog);
      // }

      return characterQuoteList;
    }

    public static string GetRandomGandalfQuote(string apiKey, string gandalfCharId)
    {
      var apiCallTask = QuotesHelper.GetAllCharQuotes(apiKey, gandalfCharId);
      var result = apiCallTask.Result;

      JObject jsonResponse = JObject.Parse(result);
      JArray quoteArray = jsonResponse["docs"].Value<JArray>();

      if (quoteArray.Count == 0)
      {
        return "No quotes available.";
      }

      Random random = new Random();
      int randomIndex = random.Next(quoteArray.Count);
      string randomQuote = quoteArray[randomIndex]["dialog"].Value<string>();

      // Console.WriteLine(randomQuote);

      return randomQuote;
    }
  }
}