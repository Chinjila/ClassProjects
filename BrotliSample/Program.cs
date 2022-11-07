//1. Create a File Stream to store compressed data
using System.IO.Compression;

FileStream outputFile = new FileStream("Compressed.File",FileMode.Create);
//2. Create a Brotli Stream with above FileStream as part of constructor
BrotliStream compressor = new BrotliStream(outputFile, CompressionLevel.SmallestSize);

//3. Use a StreamWriter to write some text in to the Brotli Stream
StreamWriter writer = new StreamWriter(compressor);

//writer.AutoFlush = true;

for (int i = 0; i < 1000; i++)
{
    writer.WriteLine($"Hello World {i}");
}

writer.Flush();//manually flush the buffer

compressor.Flush(); // must call the compressor Flush or it produce 0 byte file
//4. Don't forget to flush and close the stream
outputFile.Flush();
outputFile.Close();

//Uncompressed file to compare with the brotli stream
FileStream outputFile2 = new FileStream("Uncompressed.File", FileMode.Create);
StreamWriter writer2 = new StreamWriter(outputFile2);
//writer2.AutoFlush=true;

for (int i = 0; i < 1000; i++)
{
    writer2.WriteLine($"Hello World {i}");
}
writer2.Flush();

outputFile2.Flush();

outputFile2.Close();
Console.ReadLine();
