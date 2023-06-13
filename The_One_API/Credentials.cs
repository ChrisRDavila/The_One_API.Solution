// using The_One_API.Models;
// using Tweetinvi.Models;
// using Tweetinvi;


// namespace The_One_API
// {
//     public static class Credentials
//     {
//         public static ITwitterCredentials GenerateCredentials()
//         {
//             return new TwitterCredentials("CONSUMER_KEY", "CONSUMER_SECRET", "ACCESS_TOKEN", "ACCESS_TOKEN_SECRET");
//         }

//         public static ITwitterCredentials GenerateAppCreds()
//         {
//             var userCreds = GenerateCredentials();
//             return new TwitterCredentials(userCreds.ConsumerKey, userCreds.ConsumerSecret);
//         }
//     }
// }