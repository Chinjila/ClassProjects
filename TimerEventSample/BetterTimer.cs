using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerEventSample
{
    public delegate void delTimerRing(BetterTimer timer, BetterTimerEventArg arg);

    public class BetterTimerEventArg
    {
        public DateTime WhenStart;
        public int HowManyTimesHasItFired;
    }
    public class BetterTimer
    {
        public string Name { get; }
        public int Interval { get; }
        int howManyTimesHasItFired = 0;
        DateTime whenStart;


        bool runTimer = false;
        public event delTimerRing TimerRing;
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
            while (runTimer)
            {
                Task.Delay(Interval);
                BetterTimerEventArg betterTimerEventArg = new BetterTimerEventArg();
                betterTimerEventArg.WhenStart = whenStart;
                betterTimerEventArg.HowManyTimesHasItFired = howManyTimesHasItFired;
                TimerRing?.Invoke(this, betterTimerEventArg);
                howManyTimesHasItFired++;

            }
        }
        public void Start()
        {
            if (!runTimer)
            {
                runTimer = true;
                EngageTimer();
            }
            {

            }
        }
        public void Stop()
        {
            if (runTimer) { runTimer = false; }
        }
    }
}
