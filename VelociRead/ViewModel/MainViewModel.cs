using System.Timers;
using GalaSoft.MvvmLight;
using TextSources;

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

            StartTimer();
        }

        private EPubTextSource epub;
        private int index = 0;

        private void MoveToNextIndex()
        {
            index++;
            if (index == epub.WordCount)
            {
                index = 0;
            }
            RaisePropertyChanged("Test");
        }

        private Timer wordIncrementTimer = new Timer();

        private void StartTimer()
        {
            wordIncrementTimer.Interval = 3000;
            wordIncrementTimer.Enabled = true;
            wordIncrementTimer.Elapsed +=wordIncrementTimer_Elapsed;
        }

        private void wordIncrementTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            MoveToNextIndex();
        }

        public string Test
        {
            get
            {
                return epub[index];
            }
        }
    }
}