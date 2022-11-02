using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerEventSample
{
    public delegate void delTimerRing(BetterTimer timer, BetterTimerEventArg arg);
    public class BetterTimerEventArg {
        public DateTime WhenStart;
        public int HowManyTimesHasItFired;
    }
    public class BetterTimer
    {
        public string Name { get; }
        public int Interval { get; }
        DateTime whenStart;
        int howManyTimesHasItFired=0;

        bool runTimer = false;
        public event delTimerRing TimerRing; //this is the event
        public BetterTimer(string name, int interval, bool startNow)
        {
            Name = name;
            Interval = interval;
            if (startNow)
            {
                runTimer = true;
                EngageTimer();
            }
        }
        private void EngageTimer()
        {
            whenStart = DateTime.Now;
            while (runTimer) {
                Task.Delay(Interval);
                BetterTimerEventArg betterTimerEventArg = new()
                { HowManyTimesHasItFired= howManyTimesHasItFired,
                  WhenStart = whenStart
                };
                TimerRing?.Invoke(this, betterTimerEventArg);
                howManyTimesHasItFired++;
            }
        }
        public void Start() {
            if (!runTimer) { 
                runTimer = true;
                EngageTimer();
            }
        }

        public void Stop()
        {
            if (runTimer)
            {
                runTimer = false;
            }
        }
    }


}
