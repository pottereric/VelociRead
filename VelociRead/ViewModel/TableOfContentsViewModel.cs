using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using VelociRead.BusinessLogic;

namespace VelociRead.ViewModel
{
    public class TableOfContentsViewModel : ViewModelBase
    {
        public IEnumerable<String> ChapterList
        {
            get
            {
                var epub = EpubManager.Instance.CurrentTextSource;

                var titles = epub.Chapters.Select(c => c.Title);

                return titles;
            }
        }

        private int _selectedIndex;

        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                EpubManager.Instance.CurrentChapter = EpubManager.Instance.CurrentTextSource.Chapters[value];
            }
        }
    }
}