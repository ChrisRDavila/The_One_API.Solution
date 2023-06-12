using System;
using System.Diagnostics;
using System.Threading.Tasks;
using The_One_API.Models;
using Microsoft.AspNetCore.Mvc;
using Tweetinvi;
using Tweetinvi.Auth;
using Tweetinvi.Parameters;

namespace The_One_API.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IAuthenticationRequestStore _myAuthRequestStore = new LocalAuthenticationRequestStore();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private static ITwitterClient GetAppClient()
        {
            var appCreds = MyCredentials.GenerateAppCreds();
            return new TwitterClient(appCreds);
        }

        public async Task<ActionResult> TwitterAuth()
        {
            var appClient = GetAppClient();

            var authRequestId = Guid.NewGuid().ToString();
            var redirectPath = $"{Request.Scheme}://{Request.Host.Value}/Home/ValidateTwitterAuth";
            var redirectURL = _myAuthRequestStore.AppendAuthenticationRequestIdToCallbackUrl(redirectPath, authRequestId);
            var authenticationRequestToken = await appClient.Auth.RequestAuthenticationUrlAsync(redirectURL);
            await _myAuthRequestStore.AddAuthenticationTokenAsync(authRequestId, authenticationRequestToken);

            return new RedirectResult(authenticationRequestToken.AuthorizationURL);
        }

        public async Task<ActionResult> ValidateTwitterAuth()
        {
            var appClient = GetAppClient();

            // RequestCredentialsParameters.FromCallbackUrl does 3 things:
            // * Extract the id from the callback
            // * Get the AuthenticationRequest from the store
            // * Remove the request from the store as it will no longer need it
            // This logic can be implemented manually if you wish change the behaviour
            var requestParameters = await RequestCredentialsParameters.FromCallbackUrlAsync(Request.QueryString.Value, _myAuthRequestStore);
            var userCreds = await appClient.Auth.RequestCredentialsAsync(requestParameters);

            var userClient = new TwitterClient(userCreds);
            var user = await userClient.Users.GetAuthenticatedUserAsync();

            ViewBag.User = user;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}