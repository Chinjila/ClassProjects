using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceExample
{
    public class BetterTimer : System.Timers.Timer
    {
        public String Name;
        public int HowManyTimesHasItFired=0;
        public DateTime TimerCreatedOn;
        public BetterTimer()
        {
            this.Elapsed += BetterTimer_Elapsed1;
        }

        private void BetterTimer_Elapsed1(object? sender, System.Timers.ElapsedEventArgs e)
        {
            TimerCreatedOn = DateTime.Now;
            HowManyTimesHasItFired++;
        }
    }
    
}
