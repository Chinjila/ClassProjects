using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new blog");


//db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });

//var anotherBlog = new Blog { Url = "http://blogs.google.com/adonet" };

//db.Add(anotherBlog);

//db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
foreach (var aBlog in db.Blogs)
{
    Console.WriteLine(aBlog.Url);
    for (int i = 0; i < 10; i++)
    {
        Post p = new Post() { Blog = aBlog, Content = $"Post#{i}", Title = $"PostTitle#{i}" };
        db.Posts.Add(p);
    }
    
}

db.SaveChanges();

var result = db.Posts.Where(p => p.Title == "PostTitle#7");

foreach (var item in result)
{
    Console.WriteLine($"{item.PostId},{item.Title},{item.BlogId}");
}

//// Delete
//Console.WriteLine("Delete the blog");
//db.Remove(blog);
//db.SaveChanges();