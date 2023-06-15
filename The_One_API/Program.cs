using Tweetinvi;
using Tweetinvi.Core.Web;
using The_One_API.Models;


namespace The_One_API
{
class Program
    {
    static async Task Main(string[] args)
    {
        while (true)
        {
        await SendRandomGandalfQuoteTweet();
        await Task.Delay(TimeSpan.FromMinutes(60));
        }
    }

    static async Task SendRandomGandalfQuoteTweet()
    {
        // Retrieve a random Gandalf quote
        string randomGandalfQuote = CharacterQuote.GetRandomGandalfQuote(EnvironmentVariables.TheOneApiKey, EnvironmentVariables.GandalfCharId);
        // string randomGandalfQuote = "It's your boi, Gandalf";

        if (randomGandalfQuote.Length > 279)
        {
        randomGandalfQuote = randomGandalfQuote.Substring(0, 276) + "...";
        Console.WriteLine("The tweet has been trimmed to under 280 characters.");
        // throw new Exception("Error: this quote is too long to tweet.");
        }
        var client = new TwitterClient(EnvironmentVariables.consumerKey, EnvironmentVariables.consumerSecret, EnvironmentVariables.accessToken, EnvironmentVariables.accessSecret);

        var poster = new TweetsV2Poster(client);

        ITwitterResult result = await poster.PostTweet(
            new TweetV2PostRequest
            {
                Text = randomGandalfQuote
            }
        );

        if( result.Response.IsSuccessStatusCode == false )
        {
            throw new Exception(
                "Error when posting tweet: " + Environment.NewLine + result.Content
            );
        }
    }
}
}

