// using System;
// using System.Net.Http;
// using System.Text;
// using System.Threading.Tasks;
// using Newtonsoft.Json;



// namespace The_One_API.Services
// {
//   public class TwitterApiHelper
//   {
//     private readonly HttpClient _httpClient;
    
//     public TwitterApiHelper(HttpClient httpClient)
//   {
//       _httpClient = httpClient;
//   }
//     public async Task PostTweet(string quote, string bearerToken, string consumerKey, string consumerSecret, string accessToken, string accessSecret)
//     {
//       string apiUrl = "https://api.twitter.com/2/statuses/update.json";
      
//       HttpClient httpClient = new HttpClient();

//       _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);

//       var requestBody = new
//       {
//         status = quote
//       };

//       var json = JsonConvert.SerializeObject(requestBody);
//       var content = new StringContent(json, Encoding.UTF8, "application/json");

//       var response = await _httpClient.PostAsync(apiUrl, content);

//       if (response.IsSuccessStatusCode)
//       {
//         Console.WriteLine("Tweet posted successfully!");
//       }
//       else
//       {
//         Console.WriteLine("Error posting tweet!");
//         var responseContent = await response.Content.ReadAsStringAsync();
//         Console.WriteLine(responseContent);
//       }  
//     }
//   }
// }