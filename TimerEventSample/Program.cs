// See https://aka.ms/new-console-template for more information
using System.Timers;
using TimerEventSample;

TestSystemTimer();

Console.ReadLine();

BetterTimer betterTimer = new BetterTimer("Timer1", 3000, true);
betterTimer.TimerRing += BetterTimer_TimerRing;

void Timer_Elapsed(object? sender, ElapsedEventArgs e)
{
    if (sender is System.Timers.Timer)
    {
        System.Timers.Timer theOneWhoRaisedTheEvent = sender as System.Timers.Timer;
    }

    Console.WriteLine("Timer Event Received");
}

void TestSystemTimer()
{
    System.Timers.Timer timer = new System.Timers.Timer(2000);
    System.Timers.Timer timer2 = new System.Timers.Timer(5000);
    System.Timers.Timer timer3 = new System.Timers.Timer(3000);
    System.Timers.Timer timer4 = new System.Timers.Timer(3300);

    timer.Elapsed += Timer_Elapsed;
    timer.Enabled = true;
    timer2.Elapsed += Timer_Elapsed;
    timer2.Enabled = true;
    timer3.Elapsed += Timer_Elapsed;
    timer3.Enabled = true;
    timer4.Elapsed += Timer_Elapsed;
    timer4.Enabled = true;
}