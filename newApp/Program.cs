
namespace project
{
    class Program
    {

        FileStream newData = new FileStream("Compressed.File", FileMode.Create);
        
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }
        }
    }
}