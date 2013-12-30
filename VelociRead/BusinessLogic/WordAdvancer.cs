using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using VelociRead.ViewModel;

namespace VelociRead.BusinessLogic
{
    public class WordAdvancer : IWordAdvancer
    {
        public MainViewModel ViewModel { get; set; }

        private bool advancedBetweenTimerElapsed = false;
        private double timeOfLastAdvance = 0;
        private int currentWPM;
        private int remainingWordCount = 0;

        public void Initialize()
        {
            StartTimer();
        }

        public void Advance()
        {
            advancedBetweenTimerElapsed = true;
            if (remainingWordCount == 0)
            {
                remainingWordCount = 100;
            }
            else
            {
                remainingWordCount += 10;
            }
            double currentTime = DateTime.Now.TimeOfDay.TotalMilliseconds;

            double elapsed = currentTime - timeOfLastAdvance;

            var newWPM = (int)(600000D / elapsed);
            if (newWPM < 1000)
            {
                CurrentWPM = newWPM;
            }

            wordIncrementTimer.Interval = IntervalForWPM;

            timeOfLastAdvance = currentTime;
        }

        private int CurrentWPM
        {
            get { return currentWPM; }
            set
            {
                Debug.WriteLine(string.Format("CurrentWPM = {0}", value));
                currentWPM = value;
            }
        }

        private double IntervalForWPM
        {
            get
            {
                if (CurrentWPM == 0)
                {
                    CurrentWPM = 1;
                }
                return 60000 / CurrentWPM;
            }
        }


        private Timer wordIncrementTimer = new Timer();

        private void StartTimer()
        {
            CurrentWPM = 300;
            wordIncrementTimer.Interval = IntervalForWPM;
            wordIncrementTimer.Enabled = true;
            wordIncrementTimer.Elapsed += wordIncrementTimer_Elapsed;
            wordIncrementTimer.Start();

            timeOfLastAdvance = DateTime.Now.TimeOfDay.TotalMilliseconds;
        }

        private void wordIncrementTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (remainingWordCount > 0)
            {
                ViewModel.MoveToNextIndex();
                remainingWordCount--;

                if (!advancedBetweenTimerElapsed)
                {
                    // If there was not advance event, slow down
                    //wordIncrementTimer.Interval += 100;

                    if (CurrentWPM > 25)
                    {
                        CurrentWPM -= 25;
                        wordIncrementTimer.Interval = IntervalForWPM;
                    }
                    else
                    {
                        CurrentWPM = 1;
                    }
                }

                advancedBetweenTimerElapsed = false;
            }
        }
    }
}
