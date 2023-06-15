# One Bot to Rule them All

<img src="https://media4.giphy.com/media/TcdpZwYDPlWXC/giphy.gif?cid=ecf05e479jyx7jzqd30zruug6tlr6zew54q7ut1gdy0ctnuk&ep=v1_gifs_search&rid=giphy.gif&ct=g" width="200"/>

_This application uses a Twitter API to post randomized quotes from Gandalf as per Tolkien-related material via The One API (Lord of the Rings-themed API)_

#### By **Christopher Davila, Joseph Wilfong, Marcus Kyung, Gareth Grindeland and Laura Hope**

## Table of Contents
* 💍 [Technologies Used](#technologies-used)🌋
* 💍 [Description](#description)🌋
* 💍 [Setup & installation](#setupinstallation-requirements)🌋
* 💍 [Known-bugs](#known-bugs)🌋
* 💍 [License](#license)🌋

## Technologies Used

* _MS EF Core v 6.0.0_
* _MS EF Core Design v 6.0.0_
* _C#/.NET_
* _ASP Core MVC_
* _Newtonsoft.Json v 13.0.2_
* _RestSharp v 108.0.3_
* _TweetinviAPI v 5.0.4_
* _[The One API](https://the-one-api.dev/)_
* _[Twitter API v 2.0](https://developer.twitter.com/en/docs/twitter-api)_

## Description

_This is a Twitter Bot using C#/.NET MS EF Core framework that will post randomized quotes by the character Gandalf from the Lord of the Rings trilogy. Once initiated via the command ```dotnet run``` the bot will tweet a Gandalf quote immediately and then again every 60 minutes until the program is closed._

_You can view the tweets [@Gandalf_bot](https://twitter.com/Gandalf_bot)._

## Setup/Installation Requirements

* 1. Clone "The_One_API.Solution" from the repository to your desktop.
* 2. Open your terminal (e.g. Terminal or GitBash) and navigate to this project's directory called "The_One_API".
* 3. Set up the project:
  * Create a file in the production directory "The_One_API" called "EnvironmentVariables.cs"
  * Add the following code to the "EnvironmentVariables.cs" file:
  ```
  namespace The_One_API
  {
    public static class EnvironmentVariables
    {
      public static string TheOneApiKey = "[YOUR-ONE-API-KEY]";
      public static string GandalfCharId = "5cd99d4bde30eff6ebccfea0";
      public static string consumerKey = "[YOUR-TWITTER-API-CONSUMER-KEY]";
      public static string consumerSecret = "[YOUR-TWITTER-API-CONSUMER-SECRET]";
      public static string accessToken = "[YOUR-TWITTER-ACCESS-TOKEN]";
      public static string accessSecret = "[YOUR-TWITTER-ACCESS-SECRET]";
    }
  } 
  ```
  * Replace all information in each of the square brackets with _your one API key_, _your twitter api consumer key_, _your twitter api consumer secret_, _your twitter access token_, and _your twitter access secret_.
* 4. Setting up the necessary accounts:
#### **The One API**
  * Create an account on "The One API" via [this link](https://the-one-api.dev/) 
  * Navigate to the webpage and click the 3 horizontal bars on the top right of the screen
  * Select "sign up" and provide your email and password
  * Copy the given "Access token" and paste to the EnvironmentVariables.cs file in the [YOUR-ONE-API-KEY] section
#### **Twitter Developer Account**
  * Create a Twitter Developer account via [this link](https://developer.twitter.com/en/docs/twitter-for-websites/tools-and-libraries)
  * Navigate to the top right of the page and select "Developer Portal"
  * Click "sign up" and fill out the necessary fields
  * Navigate to the developer portal via [this link](https://developer.twitter.com/en/portal/dashboard)
  * On the main page (dashboard), select the key icon under "project app"
  * Click "regenerate" to reveal your twitter API key and API key secret
  * Copy each of these and paste them in their respective locations within the "EnvironmentVariables.cs" file:
    **[YOUR-TWITTER-API-CONSUMER-KEY] = API key**
    **[YOUR-TWITTER-API-CONSUMER-SECRET] = API key secret**
  * Within the Developer Portal Settings Tab click the "edit" button under the User Authentication Settings section. Within the User Authentication settings page select the option for Read and Write, Web App, and enter https://twitter.com/ in the Callback URLs field. Click save. The Twitter Access Tokens you will generate in the next step are now enabled with Read and Write permissions. 
  * Click "generate" to reveal your twitter access token and secret
  * Copy each of these and paste them in their respective locations within the "EnvironmentVariables.cs" file
    **[YOUR-TWITTER-ACCESS-TOKEN] = access token**
    **[YOUR-TWITTER-ACCESS-SECRET] = access secret**
  * <strong>IMPORTANT NOTE:</strong> The client will post tweets from the Twitter account used to sign up for the developer access tokens. If you wish to use Twitter's API to post from other accounts, you will have to follow the additional steps provided [here](https://developer.twitter.com/en/docs/authentication/oauth-2-0) to set up OAuth 2.0 with a Bearer Token.
* 5. Within the production directory `\The_One_API` run `\$ dotnet watch run` in the command line to build, restore and run application and producd a random Gandalf quote tweet.
* 6. Program will continue to run and post a tweet every [hour] until manually exited or limit of API calls per month is reached.


## Known Bugs

* _Twitter's API prevents duplicate tweets within a specific timeframe. Duplicate tweets result in a program error with status code 403._
* _Twitter limits posts to a maximum of 280 characters. If the randomized movie quote is beyond this limit, our code currently trims the text and adds an ellipses at the end before posting._
* _The current free version of Twitter API limits the amount of hourly and monthly requests. Visit https://developer.twitter.com/en/docs/twitter-api/getting-started/about-twitter-api for more information. Requests in excess of your allotment return a Code 429._

## License
[MIT](https://github.com/ChrisRDavila/The_One_API.Solution/blob/main/License.txt)

_Please reach out to any of us for questions, comments, or concerns: crossdavila@gmail.com, josephwilfong91@gmail.com, Kyungmj@gmail.com, gt.grindeland@gmail.com, lauramhope.dpt@gmail.com_