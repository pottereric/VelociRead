using eBdb.EpubReader;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TextSources
{
    public class ChapteredEPubTextSource : TextSources.ITextSource
    {
        private Epub CurrentEpub;

        public ChapteredEPubTextSource(string fileName)
        {
            //CurrentEpub = new Epub(@"..\..\..\TestData\pragpub-2013-07.epub");
            CurrentEpub = new Epub(fileName);
        }

        public String Title
        {
            get
            {
                return CurrentEpub.Title[0];
            }
        }

        public String Author
        {
            get
            {
                return CurrentEpub.Creator[0];
            }
        }

        public int ChapterCount
        {
            get
            {
                return CurrentEpub.Content.Count;
            }
        }

        private List<Chapter> chapters;

        public List<Chapter> Chapters
        {
            get
            {
                if (chapters == null)
                {
                    chapters = new List<Chapter>();
                    foreach (var item in CurrentEpub.Content)
                    {
                        ContentData contentItem = ((DictionaryEntry)(item)).Value as ContentData;
                        Chapter c = new Chapter(contentItem.GetContentAsPlainText());
                        chapters.Add(c);
                    }
                }
                return chapters;
            }
        }
    }
}