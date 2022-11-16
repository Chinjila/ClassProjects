// See https://aka.ms/new-console-template for more information

//Sample 2
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;


#region Sample 1
//Console.WriteLine("Sample 1".PadRight(25, '='));
//// bit mask exercise
//Sample1();
void Sample1()
{
    //linq query
    Console.WriteLine();
    string[] choices = "0|12,0|8,16|14,3072|16,32768|1".Split(',');
    Console.WriteLine($"Choices of : {String.Join(',', choices)}");
    InputToSet(0, choices);
    InputToSet(18, choices);
    InputToSet(32769, choices);

    //extension method on int
    Console.WriteLine();
    choices = "0|16,1|16,2|15,4|14".Split(',');
    Console.WriteLine($"Choices of : {String.Join(',', choices)}");
    Console.WriteLine($"input {0,-5} is in set:{0.FindSmallestSetFromChoices(choices)}");
    Console.WriteLine($"input {3,-5} is in set:{3.FindSmallestSetFromChoices(choices)}");
    Console.WriteLine($"input {7,-5} is in set:{7.FindSmallestSetFromChoices(choices)}");

}
void InputToSet(int v, string[] choices)
{
    
    var result = choices.Where(c => MaskHelper(v, c)).MaxBy(c => int.Parse(c.Split("|")[1]));// this solves problem 2
    //.OrderByDescending(c => int.Parse(c.Split("|")[1])).First();
    Console.WriteLine($"input:{v,-5} is in set:{result}");
}
static bool MaskHelper(int v, String s) // this solves problem 1
{
    //string toParse = "18|14";<--this sample
    //string toParse = "3072|15";
    string[] parts = s.Split("|"); //need to split on | symbol and obtain 2 separate strings in an array

    int mask = int.Parse(parts[1]);//this return 14 - which is the number of 1s in the mask
    var strPartTwo = new String('1', mask).PadRight(16, '0');//new String('1',mask) returns a string 
    //"11111111111111" (14 1s)
    //PadRights(16) pads the string to 16 characters with 0 as filler
    //"1111111111111100" <- this is still a string called strPartTwo

    int partOne = int.Parse(parts[0]);//0000000000010010 first part is already a number
    int partTwo = Convert.ToUInt16(strPartTwo, 2);//Convert "1111111111111100" to Unsigned Int16
    // so we can do bitwise AND between partOne and partTwo
    int inclusiveRangeStart = partOne & partTwo;
    // 0000000000010010
    // 1111111111111100
    // with an AND operation we have
    // 0000000000010000 <- that is the range start, where the last two bits will be 0

    int inclusiveRangeEnd = (int)(partOne + Math.Pow(2.0, 16 - mask)) - 1;
    // calculating the range end is 2 to the power of changing bit(16-14)=2
    // 00 + 4-1 = range end on 03
    // 16+00 to 16+03 
    return (v >= inclusiveRangeStart && v <= inclusiveRangeEnd);

}
#endregion

#region Sample 2
//Console.WriteLine("\r\nSample 2".PadRight(25, '='));
////Compression exercise
//Sample2("aaaaabvvvaaaaasdsddddaaaabbbbbsaed");

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
    
}


#endregion

#region Sample 6
//Console.WriteLine("\r\nSample 6".PadRight(25, '='));
//Sample6();

void Sample6()
{
    List<CharScanBot> bots = new() { new CharScanBot('(', ')'), new CharScanBot('[', ']'), new CharScanBot('{', '}') };
    String toScan = "{{((()]}";
    Console.WriteLine($"Input string: {toScan}");

    Parallel.ForEach(bots, 
        bot => bot.ScanThis(toScan)
        .ContinueWith(t => 
            Console.WriteLine(t.Result.TellMeWhatIamMissing())));

    Console.WriteLine("press enter for next sample");
    Console.ReadLine();
}



#endregion

#region Sample 7
//Console.WriteLine("\r\nSample 7 - standard fibonacci ".PadRight(25, '='));
//Sample7();

void Sample7()
{
    List<ulong> fibonacciSeq = GenerateFibonnaci(10);//prepare the sequence
    for (int i = 0; i <= fibonacciSeq.Count-1; i++)
    {
        Console.WriteLine($"Fibonacci number for position {i,5} is {fibonacciSeq[i],25}");
    }
    
}

//Console.WriteLine("\r\nSample 7a - fibonacci - observable sequence demo".PadRight(25, '='));
//Sample7a();

void Sample7a()
{
    int loopcounter = 0;
    List<ulong> fibonacciSeq = GenerateFibonnaci(10);
    IObservable<ulong> fibonacciSource = fibonacciSeq.ToObservable(); //we are not using a for or foreach loop here,
    //instead the element of the List is sent to our subscribed callback
    
    using (var fibonnacciSub = fibonacciSource
     .Subscribe(
     (x) => { 
        Console.WriteLine($"The {loopcounter} fib number is {x}");
        loopcounter++;
     },//callback when an element is pushed to subscribed
     (Exception ex) => Console.WriteLine("Error received from source: {0}.", ex.Message),
     () => Console.WriteLine("End of sequence.")
     )
    )//end of using
    {//start of code block that disposes fibonnacciSub when exits
        Console.WriteLine("Press enter again to unsubscribe from the service.");
        Console.ReadLine();//block the main thead here
    }//user hit enter, we are exiting the using block in 130, so fibonnacciSub is displosed of
}

//Console.WriteLine("\r\nSample 7b - fibonacci - value tuple demo".PadRight(25, '='));
//Sample7b();

void Sample7b()
{

    IEnumerator<ulong> iterator = Fibonacci().GetEnumerator();
    for (int i = 0; i <= 25; i++)
    {
        iterator.MoveNext();
        Console.WriteLine(iterator.Current);

    }
}

//Console.WriteLine("\r\nSample 7c - fibonacci - combine a and b".PadRight(25, '='));
//Sample7c();

void Sample7c()
{
    int previous = 0;
    IObservable<ulong> fibonacciSource = Fibonacci().ToObservable();
   
    fibonacciSource.TakeUntil(DateTime.Now.AddMilliseconds(15000)).Subscribe((x) => System.Diagnostics.Debug.WriteLine(x));
    //different subscribers can subscribe 

    using (var fibonnacciSub = fibonacciSource.TakeUntil(DateTime.Now.AddMilliseconds(10000))
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
Console.WriteLine("\r\nSample 7d - fibonacci - ObservableSequence - the end...".PadRight(25, '='));
Sample7d();
void Sample7d() {
    ulong first = 0;
    ulong second = 1;
    int counter = 0;
    var hardcodingFirst2Items = Observable.Generate(0,                      // Initial state value
                                   x => x < 2,      // The termination condition. Terminate generation when false (the integer squared is not less than 1000).
                                   x => x + 1,             // Iteration step function updates the state and returns the new state. In this case state is incremented by 1.
                                   x => (ulong)x);

    var realObs = Observable.Generate(
                                   0,                      // Initial state value
                                   x => 1 == 1,      // The termination condition. Terminate generation when false (the integer squared is not less than 1000).
                                   x => x + 1,             // Iteration step function updates the state and returns the new state. In this case state is incremented by 1.
                                   x => { (first, second) = (second, second + first); return second; }
    );

    hardcodingFirst2Items
        .Concat(realObs)
        .TakeUntil(x=>x>int.MaxValue)
        .Subscribe((x) => Console.WriteLine($"The {counter++} sequence of fib is {x,-10}"));

}
static IEnumerable<ulong> Fibonacci()
{
    ulong first = 0;
    ulong second = 1;

    yield return first;
    yield return second;

    while (true)
    {
        Task.Delay(1000).Wait();
        (first, second) = (second, second + first);
        yield return second;
    }
}
static List<ulong> GenerateFibonnaci(int sequenceLength)
{
    List<ulong> sequence = new List<ulong>();

    for (int i = 0; i < sequenceLength; i++)
    {
        Task.Delay(1000).Wait();
        if (i <= 1)
            sequence.Add((ulong)i);
        else
        {
            if ((sequence[i - 2] + sequence[i - 1]) > 10_000_000) { break; }
            sequence.Add(sequence[i - 2] + sequence[i - 1]);
        }
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

class CharScanBot {
    public CharScanBot(char char1, char char2)
    {
        Char1 = char1;
        Char2 = char2;
    }

    internal async Task<CharScanBot> ScanThis(string s) {
        await Task.Run(()=>_dict.Add(Char1, s.Where(c => c == Char1).Count()));
        await Task.Run(() => _dict.Add(Char2, s.Where(c => c == Char2).Count()));
        return this;
    }

    internal string TellMeWhatIamMissing()
    {
        switch (_dict[Char1] - _dict[Char2]) {
            case 0:
                return "missing nothing";
                break;
            case > 0:
                return $"You need {(_dict[Char1] - _dict[Char2])} {Char2}";
                break;
            case < 0:
                return $"You need {(_dict[Char2] - _dict[Char1])} {Char1}";
                break;

        }
    }



    private Dictionary<char,int> _dict= new();
    public char Char1 { get; }
    public char Char2 { get; }
}

static class IntExtension
{
    internal static String FindSmallestSetFromChoices(this int i, string[] choices)
    { return choices?.Where(c => MaskHelper(i, c)).MaxBy(c => int.Parse(c.Split("|")[1])); }

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