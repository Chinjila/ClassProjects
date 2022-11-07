using Microsoft.EntityFrameworkCore;

var context = new BloggingContext();

var aNewBlog = new Blog { Url = "https://www.chinzilla.com/blogs" };//create a new instance of blog

var aNewPost = new Post { Content = "Hello World", Title = "A new Blog" };//create a new instance of post

aNewBlog.Posts.Add(aNewPost);//associate post to the blog

var writer = new Writer { JoinedOn = DateTime.Now, IsVerified = true, Name = "bob" };//create new instance of writer

aNewBlog.Writers.Add(writer);//associate writer bob with the new blog

context.Blogs.Add(aNewBlog);//adding blob pulls in all related entities: writer and post
//use AddRange to add array of Writers to the context.Writers
context.Writers.AddRange(
    new Writer { JoinedOn = DateTime.Now, IsVerified = true, Name = "bob2" },
    new Writer { JoinedOn = DateTime.Now, IsVerified = false, Name = "bob3" },
    new Writer { JoinedOn = DateTime.Now, IsVerified = true, Name = "bob4" },
    new Writer { JoinedOn = DateTime.Now, IsVerified = false, Name = "bob5" },
    new Writer { JoinedOn = DateTime.Now, IsVerified = false, Name = "bob7" },
    new Writer { JoinedOn = DateTime.Now, IsVerified = false, Name = "bob6" },
    new Writer { JoinedOn = DateTime.Now, IsVerified = true, Name = "bob" });

context.SaveChanges(); //save all pending changes to the database


var query = context.Writers.Where(w => w.Name.StartsWith("bob")); //find all writers whose name starts with bob

var query2 = query.Where(w => w.IsVerified).Select(w=>new { w.Name,w.JoinedOn }); ; 
//the query is not resolved yet, so we can append additional criteria and refine our result

query2.ToList().ForEach(w => Console.WriteLine($"{w.Name} joined on {w.JoinedOn}"));//ToList will trigger a sql command execution behind the scene
//ForEach is a convenient extension method to print each writer's name to the console.

Console.ReadLine();
//.Database.SqlQuery<Writer>($"Select * from writers where witerID=1");

// How to group all writers by their name?
var query3 = (from w in context.Writers
             group w by w.Name into nameGroup
             where nameGroup.Count()>3 && nameGroup.Key.Contains("bob")
             select new { Name = nameGroup.Key, CountOfWriter = nameGroup.Count() }).Take(2);

query3.ToList().ForEach(g => Console.WriteLine(
    $"there are {g.CountOfWriter} {g.Name} in database."
    ));