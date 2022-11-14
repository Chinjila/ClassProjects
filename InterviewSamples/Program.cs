// See https://aka.ms/new-console-template for more information

//Sample 2
using System.Diagnostics.Metrics;
using System.Reactive.Linq;
using System.Text;
Console.WriteLine("Sample2");
Sample2("aaaaabvvvaaaaasdsddddaaaabbbbbsaed");
Console.WriteLine("Sample3");
Sample9("saippuakivikauppias");

void Sample9(string v)
{
    Console.WriteLine($"{v} is palindrome:");
    Console.WriteLine(v==new String(v.Reverse().ToArray()) );
}

void Sample2(string v)
{
    List<Entry> list = new List<Entry>();  
    
    for (int i = 0; i <= v.Length-1; i++)
    {
        Entry x = new Entry() { Character = v[i], Count = 1 };

        while (v[i] == v[Math.Min(i+1,v.Length-1)]) {
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


