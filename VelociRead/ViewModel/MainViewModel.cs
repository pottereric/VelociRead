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
            JumpBack = new RelayCommand(OnJumpBack);
            NextChapter = new RelayCommand(OnNextChapter);
            PreviousChapter = new RelayCommand(OnPreviousChapter);
        }

        private IWordAdvancer advancer;
        private ITextSourceFactory CurrentTextSourceFactory;
        private ITextSource epub;
        private int index = 0;

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
            if (index == CurrentChapter.WordCount)
            {
                //index = 0;
            }
            else
            {
                index++;
                while (string.IsNullOrWhiteSpace(CurrentWord))
                {
                    index++;
                }
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

        public RelayCommand Advance { get; private set; }

        public void OnAdvance()
        {
            advancer.Advance();
        }

        public RelayCommand JumpBack { get; private set; }

        public void OnJumpBack()
        {
            if (index < 50)
            {
                index = 0;
            }
            else
            {
                index -= 50;
            }
            RaisePropertyChanged("CurrentWord");
        }

        public RelayCommand PreviousChapter { get; private set; }

        public void OnPreviousChapter()
        {
            var currentChapterIndex = GetCurrentChapterIndex(); 
            if (currentChapterIndex > 0)
            {
                CurrentChapter = epub.Chapters[currentChapterIndex - 1];
                index = 0;
                RaisePropertyChanged("CurrentWord");
            }
        }

        public RelayCommand NextChapter { get; private set; }

        public void OnNextChapter()
        {
            var currentChapterIndex = GetCurrentChapterIndex();
            if (currentChapterIndex < epub.Chapters.Count)
            {
                CurrentChapter = epub.Chapters[currentChapterIndex + 1];
                index = 0;
                RaisePropertyChanged("CurrentWord");
            }
        }

        private int GetCurrentChapterIndex()
        {
            var currentChapterIndex = epub.Chapters.FindIndex(c => c.Title == CurrentChapter.Title && c.WordCount == CurrentChapter.WordCount);
            return currentChapterIndex;
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