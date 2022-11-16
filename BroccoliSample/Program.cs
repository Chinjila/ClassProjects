//1. create file stream to store compressed data

//2. create a brotli stream with above FileStream as part of constuctor

//3. use a streamwriter to write some text in to the brotli stream

//4 flush and close stream

using System.IO.Compression;

Console.WriteLine("Heelo");
FileStream fs = new FileStream("Compressed.File", FileMode.Create);
BrotliStream bs = new BrotliStream(fs, CompressionLevel.SmallestSize);
StreamWriter StreamWriter = new StreamWriter(bs);

for (int i = 0; i < 1000; i++)
{
    StreamWriter.WriteLine($"hello {i}");
}
fs.Flush();
bs.Flush();
StreamWriter.Flush();
fs.Close();

FileStream fs2 = new FileStream("Uncompressed.File", FileMode.Create);
StreamWriter StreamWriter2 = new StreamWriter(fs2);

for (int i = 0; i < 1000; i++)
{
    StreamWriter2.WriteLine($"hello {i}");
}
fs2.Flush();
StreamWriter2.Flush();
fs2.Close();