// See https://aka.ms/new-console-template for more information
using System.Timers;

System.Timers.Timer timer = new System.Timers.Timer(2000);
System.Timers.Timer timer2 = new System.Timers.Timer(5000);
System.Timers.Timer timer3 = new System.Timers.Timer(3000);


timer.Elapsed += Timer_Elapsed;
timer.Enabled = true;
timer2.Elapsed += Timer_Elapsed;
timer2.Enabled = true;
timer3.Elapsed += Timer_Elapsed;
timer3.Enabled = true;

Console.ReadLine();

void Timer_Elapsed(object? sender, ElapsedEventArgs e)
{
    if (sender is System.Timers.Timer)
    { 
        System.Timers.Timer theOneWhoRaisedTheEvent = sender as System.Timers.Timer; 
    }

 Console.WriteLine("Timer Event Received");
}