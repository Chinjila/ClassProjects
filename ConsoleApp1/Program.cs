using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TimerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BetterTimer timer = new BetterTimer("Timer1", 2000, false);
            timer.timerRing += BetterTimer_TimerRing;
            timer.Start();
            BetterTimer timer2 = new BetterTimer("Timer2", 1000, false);
            timer.timerRing += BetterTimer_TimerRing;
            


            Task t1 = new Task(()=> timer.Start());
            Task t2 = new Task(() => timer2.Start());
            


            Console.ReadLine();
            timer.Stop();
            timer2.Stop();
            Console.ReadLine();
        }

        public static void BetterTimer_TimerRing(BetterTimer timer, BetterTimerEventArgs arg)
        {
            Console.WriteLine($"Timer {timer.Name} has gone off for the {arg.HowManyTimesHasItfired} time since {arg.WhenStart}.");
        }
    }
}
