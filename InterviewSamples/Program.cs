// See https://aka.ms/new-console-template for more information

//Sample 2
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;


#region Sample 1
Console.WriteLine("Sample 1".PadRight(25, '='));
// bit mask exercise
Sample1();
void Sample1()
{
    //linq query
    Console.WriteLine();
    string[] choices = "\t0|12,0|8,16|14,3072|16,32768|1".Split(',');
    Console.WriteLine($"Choices of : {String.Join(',', choices)}");
    InputToSet(0, choices);
    InputToSet(18, choices);
    InputToSet(32769, choices);
    //extension method on int
    Console.WriteLine();
    choices = "0|16,1|16,2|15,4|14".Split(',');
    Console.WriteLine($"Choices of : {String.Join(',', choices)}");
    Console.WriteLine($"input {0,-5} is in set:{0.FindSet(choices)}");
    Console.WriteLine($"input {3,-5} is in set:{3.FindSet(choices)}");
    Console.WriteLine($"input {7,-5} is in set:{7.FindSet(choices)}");

}
void InputToSet(int v, string[] choices)
{
    var result = new List<string>(choices).Where(c => MaskHelper(v, c)).MaxBy(c => int.Parse(c.Split("|")[1]));
    //.OrderByDescending(c => int.Parse(c.Split("|")[1])).First();
    Console.WriteLine($"input:{v,-5} is in set:{result}");
}
static bool MaskHelper(int v, String s)
{
    //string toParse = "16|14";
    //string toParse = "3072|15";
    string[] parts = s.Split("|");

    int mask = int.Parse(parts[1]);
    var strPartTwo = new String('1', mask).PadRight(16, '0');
    int partOne = int.Parse(parts[0]);
    int partTwo = Convert.ToUInt16(strPartTwo, 2);

    int inclusiveRangeStart = partOne & partTwo;
    int inclusiveRangeEnd = (int)(partOne + Math.Pow(2.0, 16 - mask)) - 1;


    return (v >= inclusiveRangeStart && v <= inclusiveRangeEnd);

}
#endregion

#region Sample 2
Console.WriteLine("\r\nSample 2".PadRight(25, '='));
//Compression exercise
Sample2("aaaaabvvvaaaaasdsddddaaaabbbbbsaed");

void Sample2(string v)
{

    List<Entry> list = new List<Entry>();

    for (int i = 0; i <= v.Length - 1; i++)
    {
        Entry x = new Entry() { Character = v[i], Count = 1 };

        while (v[i] == v[Math.Min(i + 1, v.Length - 1)])
        {
            if (++i > v.Length - 1) { break; }
            x.Count++;
        }
        list.Add(x);
    }
    foreach (var item in list)
    {
        Console.Write($"{item.Character}{item.Count}");

    }
    Console.WriteLine("");
    Console.WriteLine("---------------------");
}


#endregion

#region Sample 7
Console.WriteLine("\r\nSample 7a - fibonacci - observable sequence demo".PadRight(25, '='));
Sample7();

void Sample7()
{
    List<ulong> fibonacciSeq = GenerateFibonnaci(10);
    IObservable<ulong> fibonacciSource = fibonacciSeq.ToObservable();
    using (var fibonnacciSub = fibonacciSource.SubscribeOn(TaskPoolScheduler.Default)
     .Subscribe(
     (x) => Console.WriteLine(x),
     (Exception ex) => Console.WriteLine("Error received from source: {0}.", ex.Message),
     () => Console.WriteLine("End of sequence.")
     )
 )
    {
        Console.WriteLine("Press enter again to unsubscribe from the service.");
        Console.ReadLine();
    }
}

Console.WriteLine("\r\nSample 7b - fibonacci - value tuple demo".PadRight(25, '='));
Sample7b();

void Sample7b()
{
    IEnumerator<ulong> iterator = Fibonacci().GetEnumerator();
    for (int i = 0; i <= 10; i++)
    {
        iterator.MoveNext();
        Console.WriteLine(iterator.Current);

    }
}

Console.WriteLine("\r\nSample 7c - fibonacci - combine a and b".PadRight(25, '='));
Sample7c();

void Sample7c()
{
    IObservable<ulong> fibonacciSource = Fibonacci().ToObservable();
    using (var fibonnacciSub = fibonacciSource.Take(10).SubscribeOn(TaskPoolScheduler.Default)
     .Subscribe(
     (x) =>
     {
         Console.WriteLine(x);
     },
     (Exception ex) => Console.WriteLine("Error received from source: {0}.", ex.Message),
     () => Console.WriteLine("End of sequence.")
     )
 )
    {
        Console.WriteLine("Press enter again to unsubscribe from the service.");
        Console.ReadLine();
    }

}

static IEnumerable<ulong> Fibonacci()
{
    ulong first = 0;
    ulong second = 1;

    yield return first;
    yield return second;

    while (true)
    {
        (first, second) = (second, second + first);
        yield return second;
    }
}
static List<ulong> GenerateFibonnaci(int sequenceLength)
{
    List<ulong> sequence = new List<ulong>();

    for (int i = 0; i < sequenceLength; i++)
    {
        if (i <= 1)
            sequence.Add((ulong)i);
        else
            sequence.Add(sequence[i - 2] + sequence[i - 1]);
    }

    return sequence;
}
Console.WriteLine("\r\nSample 3".PadRight(25, '='));

#endregion
#region Sample 9
Sample9a();

void Sample9a()
{
    var client = new HttpClient();
    var request = new HttpRequestMessage
    {
        Method = HttpMethod.Get,
        RequestUri = new Uri("https://bing-news-search1.p.rapidapi.com/news?textFormat=Raw&safeSearch=Off"),
        Headers =
    {
        { "X-BingApis-SDK", "true" },
        { "X-RapidAPI-Key", "c2738f8bc0mshcc0331a25b7d018p1e7966jsne3e1b9d39117" },
        { "X-RapidAPI-Host", "bing-news-search1.p.rapidapi.com" },
    },
    };
    using (var response =  client.SendAsync(request).Result)
    {
        //produce distinct list of word for each news description
        response.EnsureSuccessStatusCode();
        var jsonResult = JsonSerializer.Deserialize<Root>(response.Content.ReadAsStream());
        var distinctList = jsonResult?.value.Select(v => v.description.Split(' ').Distinct()).ToList();
        distinctList?.ForEach(item => Console.WriteLine(String.Join(" ", item)));
    }
    
}
Sample9b("saippuakivikauppias");
void Sample9b(string v)
{
    Console.WriteLine($"{v} is palindrome:");
    Console.WriteLine(v == new String(v.Reverse().ToArray()));
}

#endregion




#region Helper classes
class Entry
{
    internal char Character;
    internal int Count;
}


static class IntExtension
{
    internal static String FindSet(this int i, string[] choices)
    { return new List<string>(choices).Where(c => MaskHelper(i, c)).OrderByDescending(c => int.Parse(c.Split("|")[1])).First(); }

    static bool MaskHelper(int v, String s)
    {
        //string toParse = "16|14";
        //string toParse = "3072|15";
        string[] parts = s.Split("|");


        var strPartTwo = new String('1', int.Parse(parts[1])).PadRight(16, '0');
        int partOne = int.Parse(parts[0]);
        int partTwo = Convert.ToUInt16(strPartTwo, 2);

        int inclusiveRangeStart = partOne & partTwo;
        int inclusiveRangeEnd = (int)(partOne + Math.Pow(2.0, 16 - int.Parse(parts[1]))) - 1;


        return (v >= inclusiveRangeStart && v <= inclusiveRangeEnd);

    }

}

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Image
{
    public string _type { get; set; }
    public Thumbnail thumbnail { get; set; }
    public bool isLicensed { get; set; }
}

public class Provider
{
    public string _type { get; set; }
    public string name { get; set; }
    public Image image { get; set; }
}

public class Root
{
    public string _type { get; set; }
    public string webSearchUrl { get; set; }
    public List<Value> value { get; set; }
}

public class Thumbnail
{
    public string _type { get; set; }
    public string contentUrl { get; set; }
    public int width { get; set; }
    public int height { get; set; }
}

public class Value
{
    public string _type { get; set; }
    public string name { get; set; }
    public string url { get; set; }
    public Image image { get; set; }
    public string description { get; set; }
    public List<Provider> provider { get; set; }
    public DateTime datePublished { get; set; }
}


#endregion