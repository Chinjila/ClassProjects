// See https://aka.ms/new-console-template for more information

//Sample 2
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Text;

Sample1();



Console.WriteLine("Sample2");
Sample2("aaaaabvvvaaaaasdsddddaaaabbbbbsaed");

Console.WriteLine("Sample3");
Sample9("saippuakivikauppias");


void Sample1()
{
    string[] choices = "0|12,0|8,16|14,3072|16,32768|1".Split(',');
    Console.WriteLine($"Choices of : {String.Join(',', choices)}");
    InputToSet(0, choices);
    InputToSet(18, choices);
    InputToSet(32769, choices);
    choices = "0|16,1|16,2|15,4|14".Split(',');
    Console.WriteLine($"Choices of : {String.Join(',', choices)}");
    Console.WriteLine($"input {0,-5} is in set:{0.FindSet(choices)}");
    Console.WriteLine($"input {3,-5} is in set:{3.FindSet(choices)}");
    Console.WriteLine($"input {7,-5} is in set:{7.FindSet(choices)}");
    
}


void InputToSet(int v, string[] choices)
{
    var result = new List<string>(choices).Where(c => MaskHelper(v, c)).OrderByDescending(c => int.Parse(c.Split("|")[1])).First();
    Console.WriteLine($"input:{v,-5} is in set:{result}");
}

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

void Sample9(string v)
{
    Console.WriteLine($"{v} is palindrome:");
    Console.WriteLine(v == new String(v.Reverse().ToArray()));
}

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


class Entry
{
    internal char Character;
    internal int Count;
}


static class IntExtension { 
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