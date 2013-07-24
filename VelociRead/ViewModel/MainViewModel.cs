using System.Timers;
using GalaSoft.MvvmLight;
using TextSources;
using GalaSoft.MvvmLight.Command;

namespace VelociRead.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {


            epub = new EPubTextSource();

            Advance = new RelayCommand(OnAdvance);

            StartTimer();
        }

        private EPubTextSource epub;
        private int index = 0;

        public RelayCommand Advance { get; private set; }



        private void MoveToNextIndex()
        {
            index++;
            while (string.IsNullOrWhiteSpace(CurrentWord))
            {
                index++;
            }

            if (index == epub.WordCount)
            {
                index = 0;
            }
            RaisePropertyChanged("CurrentWord");
        }

        public string CurrentWord
        {
            get
            {
                return epub[index].Trim();
            }
        }

        public void OnAdvance()
        {
            remainingWorkCount += 10;
            wordIncrementTimer.Interval -= 50;
        }

        private Timer wordIncrementTimer = new Timer();

        int remainingWorkCount = 0;

        private void StartTimer()
        {
            wordIncrementTimer.Interval = 500;
            wordIncrementTimer.Enabled = true;
            wordIncrementTimer.Elapsed +=wordIncrementTimer_Elapsed;
            wordIncrementTimer.Start();

            remainingWorkCount = 10;
        }

        private void wordIncrementTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MoveToNextIndex();
            remainingWorkCount--;

            if (remainingWorkCount == 0)
            {
                wordIncrementTimer.Stop();
                wordIncrementTimer.Interval = 500;
            }
        }


       

    }
}