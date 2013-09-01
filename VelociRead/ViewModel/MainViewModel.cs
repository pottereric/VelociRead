using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Diagnostics;
using System.Timers;
using System.Linq;
using TextSources;
using VelociRead.BusinessLogic;

namespace VelociRead.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            //epub = new FlatEPubTextSource();
            epub = new ChapteredEPubTextSource();
            EpubManager.Instance.CurrentTextSource = epub;
            CurrentChapter = epub.Chapters.First();

            Advance = new RelayCommand(OnAdvance);
            ShowTableOfContents = new RelayCommand(OnShowTableOfContents);

            StartTimer();
        }

        private int currentWPM;

        public int CurrentWPM
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
                return 60000 / CurrentWPM;
            }
        }

        private void StartTimer()
        {
            CurrentWPM = 300;
            wordIncrementTimer.Interval = IntervalForWPM;
            wordIncrementTimer.Enabled = true;
            wordIncrementTimer.Elapsed += wordIncrementTimer_Elapsed;
            wordIncrementTimer.Start();

            timeOfLastAdvance = DateTime.Now.TimeOfDay.TotalMilliseconds;
        }

        private ITextSource epub;
        private int index = 0;
        private Timer wordIncrementTimer = new Timer();
        private int remainingWordCount = 0;

        public RelayCommand Advance { get; private set; }

        private Chapter CurrentChapter
        {
            get
            {
                return EpubManager.Instance.CurrentChapter;
            }
            set
            {
                EpubManager.Instance.CurrentChapter = value;
            }
        }

        private void MoveToNextIndex()
        {
            index++;
            while (string.IsNullOrWhiteSpace(CurrentWord))
            {
                index++;
            }

            if (index == CurrentChapter.WordCount)
            {
                index = 0;
            }
            RaisePropertyChanged("CurrentWord");
        }

        public string CurrentWord
        {
            get
            {
                return CurrentChapter[index].Trim();
            }
        }

        private bool advancedBetweenTimerElapsed = false;
        private double timeOfLastAdvance = 0;

        public void OnAdvance()
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
            

            CurrentWPM = (int)(600000D / elapsed);
            wordIncrementTimer.Interval = IntervalForWPM;

            timeOfLastAdvance = currentTime;
        }

        private void wordIncrementTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (remainingWordCount > 0)
            {
                MoveToNextIndex();
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


        public RelayCommand ShowTableOfContents { get; private set; }
        public void OnShowTableOfContents()
        {
            var toc = new TableOfContents();
            toc.ShowDialog();
            index = 0;
            
        }
    }
}