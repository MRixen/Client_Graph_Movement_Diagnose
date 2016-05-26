using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication6
{
    public class GlobalDataSet
    {
        private long timerValue;
        private bool debugMode;
        private Stopwatch timer_programExecution = new Stopwatch();

        public bool DebugMode
        {
            get
            {
                return debugMode;
            }

            set
            {
                debugMode = value;
            }
        }

        public Stopwatch Timer_programExecution
        {
            get
            {
                return timer_programExecution;
            }

            set
            {
                timer_programExecution = value;
            }
        }

        public long TimerValue
        {
            get
            {
                return timerValue;
            }

            set
            {
                timerValue = value;
            }
        }
    }
}
