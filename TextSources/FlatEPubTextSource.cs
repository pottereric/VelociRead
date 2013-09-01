using eBdb.EpubReader;
using System.Collections.Generic;

namespace TextSources
{
    public class FlatEPubTextSource : ITextSource
    {
        private Epub epub;

        public FlatEPubTextSource()
        {
            //Epub epub = new Epub(@"C:\Users\eric.potter\Dropbox\ReadingMaterial\pragpub-2013-01.epub");
            epub = new Epub(@"H:\Dropbox\ReadingMaterial\pragpub-2013-01.epub");
        }

        public string Author
        {
            get { return epub.Creator[0]; }
        }

        public int ChapterCount
        {
            get { return 1; }
        }

        public List<Chapter> Chapters
        {
            get
            {
                //Get all book content as plain text
                string plainText = epub.GetContentAsPlainText();

                var onlyChapter = new Chapter(plainText);
                var chapterList = new List<Chapter>();
                chapterList.Add(onlyChapter);

                return chapterList;
            }
        }

        public string Title
        {
            get { return epub.Title[0]; }
        }
    }
}