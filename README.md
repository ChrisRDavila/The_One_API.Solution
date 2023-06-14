# The One API

_This application uses a Twitter Bot API that posts randomized quotes from Gandalf the White as per Tolkien-related material_

#### By **Christopher Davila, Joseph Wilfong, Marcus Kyung, Gareth Grindeland and Laura Hope**

## Technologies Used

* _dot net 6.0_
* _cshtml_
* _C#_
* _ASP Core MVC_
* _MS Build_
* _Newtonsoft_
* _RestSharp_
* _Tweetinvi_

## Description

_This is a Twitter Bot using C# dotnet avc framework that will post randomized quotes by the character Ganldalf from all JRR Tolkein material. Once mentioned it is set up to post a reply in 10 minutes._

## Setup/Installation Requirements

* _1_
* _X. _dotnet add package MySqlConnector -v 2.2.0_
* _8. _create the file appsettings.json, and what code to include in it. We recommend using the above formatting and directing users to replace [YOUR-USERNAME-HERE] and [YOUR-PASSWORD-HERE] with the user's own user and password values. also add [YOUR-DB-NAME] with database used_
* _this format -> 
<!-- {
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[YOUR-DB-NAME];uid=[YOUR-USER-HERE];pwd=[YOUR-PASSWORD-HERE];"
  }
} -->
* _2. Open your terminal (e.g., Terminal or GitBash) and navigate to this project's production directory called "ProjectFile"._
* _3. In the command line, run the command `\$ dotnet run` to compile and execute the console application. Since this is a console application, you'll interact with it through text commands in your terminal._
* _4. Optionally, you can run `\$ dotnet build` to compile this console app without running it._
* _5. Use `\$ dotnet test run` in the Test directory to run test on the application_
* _6. use `\$ dotnet watch run` to cycle the server_
* _7. use `\$ dotnet watch run --launch-profile "production"` to run in production mode_


## Known Bugs

* _Variables set up in secret file instead of using Oath_
* _should go here_

## License
[MIT](https://github.com/ChrisRDavila/The_One_API.Solution/blob/main/License.txt)
