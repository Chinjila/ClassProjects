// See https://aka.ms/new-console-template for more information
using System;
using System.Text.Json;

HttpClient client = new();
var destinationFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\xkcd";
if (!Directory.Exists(destinationFolder)) {
    Directory.CreateDirectory(destinationFolder);   
}

//string url = "https://xkcd.com/1500/info.0.json";
for (int i = 1000; i < 1200; i++)
{
    var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, $"https://xkcd.com/{i}/info.0.json"));
    if (response.IsSuccessStatusCode) {

        var stream = await client.GetStreamAsync($"https://xkcd.com/{i}/info.0.json");

        var aComic = await JsonSerializer.DeserializeAsync<Comic>(stream);

        var imgResponse = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, aComic?.img));
        if (imgResponse.IsSuccessStatusCode) {

            var comicStream = await client.GetStreamAsync(aComic?.img);
            var fileStream = File.Create(destinationFolder + $"\\{i}.png");
            comicStream.CopyTo(fileStream);

            Console.WriteLine($"Comic {i} downloaded - {fileStream.Length} bytes");
            fileStream.Close();
            comicStream.Close();
        }
        
    }
    
}
record class Comic(
    string img,
    string title
    );
