using System.Text;
using Newtonsoft.Json;
using Tweetinvi;
using Tweetinvi.Core.Web;
using Tweetinvi.Models;

namespace The_One_API
{
    public class TweetsV2Poster
    {
        // ----------------- Fields ----------------

        private readonly ITwitterClient client;

        // ----------------- Constructor ----------------

        public TweetsV2Poster( ITwitterClient client )
        {
            this.client = client;
        }

        public Task<ITwitterResult> PostTweet( TweetV2PostRequest tweetParams )
        {
            return this.client.Execute.AdvanceRequestAsync(
                ( ITwitterRequest request ) =>
                {
                    var jsonBody = this.client.Json.Serialize( tweetParams );

                    var content = new StringContent( jsonBody, Encoding.UTF8, "application/json" );

                    request.Query.Url = "https://api.twitter.com/2/tweets";
                    request.Query.HttpMethod = Tweetinvi.Models.HttpMethod.POST;
                    request.Query.HttpContent = content;
                }
            );
        }
    }
    public class TweetV2PostRequest
    {
        // text of the tweet to post
        [JsonProperty( "text" )]
        public string Text { get; set; } = string.Empty;
    }
}