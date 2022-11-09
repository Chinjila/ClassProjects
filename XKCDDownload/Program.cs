// See https://aka.ms/new-console-template for more information
using System;
using System.Reflection;
using System.Text.Json;

HttpClient client = new(new HttpClientHandler
{
    AllowAutoRedirect = true,
    MaxAutomaticRedirections = 2
});
var destinationFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + "\\xkcd";
if (!Directory.Exists(destinationFolder)) {
    Directory.CreateDirectory(destinationFolder);   
}
List<Task> tasks = new List<Task>();
List<string>? imgList = new List<string>();
//string url = "https://xkcd.com/1500/info.0.json";
if (File.Exists("list.json"))
{ 
    imgList=JsonSerializer.Deserialize<List<string>>(File.Open("list.json",FileMode.Open));
}
else
{
    for (int i = 400; i < 1600; i++)
    {
        try
        {
            var stream = await client.GetStreamAsync($"https://xkcd.com/{i}/info.0.json");
            var aComic = await JsonSerializer.DeserializeAsync<Comic>(stream);
            imgList.Add(aComic!.img);
        }
        catch (Exception)
        {

            Console.WriteLine($"https://xkcd.com/{i}/info.0.json download failed");
        }

    }
    File.WriteAllText("list.json", JsonSerializer.Serialize(imgList));
}
Parallel.ForEach(imgList!,new ParallelOptions { MaxDegreeOfParallelism=8 },(imgUrl,state,index) => {
    var task = client.GetStreamAsync(imgUrl).ContinueWith(
             async (t) => { await t.Result.CopyToAsync(File.Create(destinationFolder + $"\\{index}.png")); Console.WriteLine($"file {index} completed"); }
             );
        tasks.Add(task);
    }

    );
Task.WaitAll(tasks.ToArray());
Console.WriteLine("Done");
record class Comic(
    string img,
    string title
    );
