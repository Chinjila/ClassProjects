



using GithubClient;
using System.Net.Http.Headers;
using System.Text.Json;

using HttpClient client = new();

client.DefaultRequestHeaders.Accept.Clear();

//client.DefaultRequestHeaders.Accept.Add(
//   new MediaTypeWithQualityHeaderValue("application/vnd.github+json",0.6));//this header tells github that we want JSON result instead of html web pages
//client.DefaultRequestHeaders.Accept.Add(
//   new MediaTypeWithQualityHeaderValue("text/xml", 0.9));//this header tells github that we want JSON result instead of html web pages
//client.DefaultRequestHeaders.Accept.Add(
//   new MediaTypeWithQualityHeaderValue("text/html", 0.3));//this header tells github that we want JSON result instead of html web pages

//client.DefaultRequestHeaders.Add("Accept", "application/vnd.github+json");
client.DefaultRequestHeaders.Add("User-Agent", "I am a .net program"); // Github will use this information in their report so they know how many ppl use chrome
//firefox etc.


List<Repository> repositories = await ProcessRepositoriesAsync(client);


foreach (var repo in repositories)
{
    Console.WriteLine($"Name: {repo.Name}");
    Console.WriteLine($"Homepage: {repo.Homepage}");
    Console.WriteLine($"GitHub: {repo.GitHubHomeUrl}");
    Console.WriteLine($"Description: {repo.Description}");
    Console.WriteLine($"Watchers: {repo.Watchers:#,0}");
    Console.WriteLine();
}

Console.WriteLine("The program is done.");
static async Task<List<Repository>> ProcessRepositoriesAsync(HttpClient client)
{

    await using Stream stream =
      await client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
    var repositories =
        await JsonSerializer.DeserializeAsync<List<Repository>>(stream);
    return repositories ?? new();

}

