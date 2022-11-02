using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{



    public delegate void TimerRing(BetterTimer timer, BetterTimerEventArgs arg);

    public class BetterTimerEventArgs
    {
        public DateTime WhenStart;
        public int HowManyTimesHasItfired;
    }
    public class BetterTimer
    {
        public bool runTimer = false;
        DateTime whenStart;
        int homManyTimesFired = 0;
        public event TimerRing timerRing;
        public BetterTimer(string name, int interval, bool start)
        {
            Name = name;
            Interval = interval;
            if (start)
                runTimer = true;
            Task t = new Task(async ()=> await EngageTimer());
            t.Start();

        }

        private async Task EngageTimer()
        {
            whenStart = DateTime.Now;
            while (runTimer)
            {
                await Task.Delay(Interval);   
                BetterTimerEventArgs timerEventArgs = new BetterTimerEventArgs()
                {
                    HowManyTimesHasItfired = homManyTimesFired,
                    WhenStart = whenStart
                };
            timerRing?.Invoke(this, timerEventArgs);
                homManyTimesFired++;
            }
        }

        public void Start()
        {
            if (!runTimer)
            {
                runTimer = true;
                EngageTimer();
            }

        }
        public void Stop()
            {
                if (runTimer)
                    runTimer = false;
            }

        public string Name { get; }
        public int Interval { get; }

    }
}
