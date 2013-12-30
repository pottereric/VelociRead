using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
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
        public MainViewModel(ITextSourceFactory textSourceFactory, IWordAdvancer advancer)
        {
            CurrentTextSourceFactory = textSourceFactory;

            OnOpenFile();

            SetCommandHandlers();

            this.advancer = advancer;
            this.advancer.ViewModel = this;
            this.advancer.Initialize();
        }

        public MainViewModel(ITextSourceFactory textSourceFactory, IWordAdvancer advancer, string fileName)
        {
            CurrentTextSourceFactory = textSourceFactory;

            SetCurrentFile(fileName);

            SetCommandHandlers();

            this.advancer = advancer;
            this.advancer.ViewModel = this;
            this.advancer.Initialize();
        }

        private void SetCommandHandlers()
        {
            Advance = new RelayCommand(OnAdvance);
            ShowTableOfContents = new RelayCommand(OnShowTableOfContents);
            OpenFile = new RelayCommand(OnOpenFile);
        }

        private IWordAdvancer advancer;
        private ITextSourceFactory CurrentTextSourceFactory;
        private ITextSource epub;
        private int index = 0;

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

        public void MoveToNextIndex()
        {
            index++;
            while (string.IsNullOrWhiteSpace(CurrentWord))
            {
                index++;
            }

            if (index == CurrentChapter.WordCount)
            {
                //index = 0;
            }
            else
            {
                RaisePropertyChanged("CurrentWord");
            }
        }

        public string CurrentWord
        {
            get
            {
                return CurrentChapter[index].Trim();
            }
        }

        public void OnAdvance()
        {
            advancer.Advance();
        }

        public RelayCommand ShowTableOfContents { get; private set; }

        public void OnShowTableOfContents()
        {
            var toc = new TableOfContents();
            toc.ShowDialog();
            index = 0;
        }

        public RelayCommand OpenFile { get; private set; }

        public void OnOpenFile()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;

                SetCurrentFile(filename);
            }
        }

        public void SetCurrentFile(string filename)
        {
            epub = CurrentTextSourceFactory.GetTextSource(filename);
            EpubManager.Instance.CurrentTextSource = epub;
            CurrentChapter = epub.Chapters.First();
        }
    }
}