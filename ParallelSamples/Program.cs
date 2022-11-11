// See https://aka.ms/new-console-template for more information

int i = 0;

for (int index = 0; index < 100; index++)
{
    i++;
}

Console.WriteLine(i);
int j = 0;
Task.Run(() =>
{
    Parallel.For(0, 100000000000,
    (index) => { j++; }
    );
});



Task<string> firstTask = new Task<string>(() => "Hello");
// Create the continuation task.  
// The delegate takes the result of the antecedent task as an argument. 
Task<int> secondTask = firstTask
    .ContinueWith((antecedent) =>
            {
                return String.Format("{0}, World!", antecedent.Result);
            })
    .ContinueWith<int>((antecedent) => { Console.WriteLine(antecedent.Result); return 100; });

;
// Start the antecedent task. 
firstTask.Start();
// Use the continuation task's result. 
Console.WriteLine(secondTask.Result);
// Displays "Hello, World!" 
//////////////////////////////////////////////////////child task//////////////////
//Detached Child
var parent = Task.Factory.StartNew(() => {
    Console.WriteLine("Outer task executing.");

    var child = Task.Factory.StartNew(() => {
        Console.WriteLine("Nested task starting.");
        Thread.SpinWait(500000);
        Console.WriteLine("Nested task completing.");
    });
});

parent.Wait();
Console.WriteLine("Outer has completed.");
Console.ReadLine();

//attached children tasks to a parent, so wait on parent is implicitly waiting on all child tasks

var parent2 = Task.Factory.StartNew(() => {
    Console.WriteLine("Parent task executing.");
    var child1 = Task.Factory.StartNew(() => {
        Console.WriteLine("Attached child starting.");
        Thread.SpinWait(50000);
        Console.WriteLine("Attached child completing.");
    }, TaskCreationOptions.AttachedToParent);
    var child2 = Task.Factory.StartNew(() => {
        Console.WriteLine("Attached child2 starting.");
        Thread.SpinWait(50000);
        Console.WriteLine("Attached child2 completing.");
    }, TaskCreationOptions.AttachedToParent);
    var child3 = Task.Factory.StartNew(() => {
        Console.WriteLine("Attached child3 starting.");
        Thread.SpinWait(50000);
        Console.WriteLine("Attached child3 completing.");
    }, TaskCreationOptions.AttachedToParent);//Task.Factory.StartNew accepts TaskCreationOptions
});
parent2.Wait();
Console.WriteLine("Parent has completed.");

//Exception
//var parent3 = Task.Factory.StartNew(() => {
//    Console.WriteLine("Parent task executing.");
//    var child1 = Task.Factory.StartNew(() => {
//        Console.WriteLine("Attached child starting.");
//        Thread.SpinWait(50000);
//        throw new Exception("Child1Exception");
//        Console.WriteLine("Attached child completing.");
//    }, TaskCreationOptions.AttachedToParent);
//    var child2 = Task.Factory.StartNew(() => {
//        Console.WriteLine("Attached child2 starting.");
//        throw new Exception("Child2Exception");
//        Thread.SpinWait(50000);
//        Console.WriteLine("Attached child2 completing.");
//    }, TaskCreationOptions.AttachedToParent);
//    var child3 = Task.Factory.StartNew(() => {
//        Console.WriteLine("Attached child3 starting.");
//        Thread.SpinWait(50000);
//        Console.WriteLine("Attached child3 completing.");
//    }, TaskCreationOptions.AttachedToParent);//Task.Factory.StartNew accepts TaskCreationOptions
//});

//try
//{
//    parent3.Wait();
//}
//catch (AggregateException ae)
//{
//    foreach (var item in ae.InnerExceptions)
//    {
//        Console.WriteLine($"Caught {item.Message}");
//    }
    
//}
//parent3.Wait();
//Console.WriteLine("Parent has completed.");
//
var result1 = MethodA(1);

Console.WriteLine($"I am main thread {Thread.CurrentThread.ManagedThreadId}");
//Demo async keyword
await result1;
Console.ReadLine();
static async Task<string> MethodA(int i) {
    Task t = Task.Run(async () => { await Task.Delay(5000); Console.WriteLine($"{i}-in a task inside of MethodA"); });


    //t.Wait();
    Console.WriteLine($"Who am I? - {Thread.CurrentThread.ManagedThreadId}");

    await t;
    Console.WriteLine($"Who am I NOW?? - {Thread.CurrentThread.ManagedThreadId}");
    Console.WriteLine("MethodA after Task.Run");
    return "test123";
}

//atypical vs atypical
//asymmetrical vs symmetrical
//asychornous vs synchronous
//asymptomatic vs symptomatic

//wait mean wait, await means don't wait