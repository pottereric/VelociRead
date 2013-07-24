using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eBdb.EpubReader;

namespace TextSources
{
    public class EPubTextSource
    {
        public EPubTextSource()
        {
            //Init epub object.
            //Epub epub = new Epub(@"C:\Users\eric.potter\Dropbox\ReadingMaterial\pragpub-2013-01.epub");
            Epub epub = new Epub(@"H:\Dropbox\ReadingMaterial\pragpub-2013-01.epub");

            //Get book title (Every epub file can have multiple titles)
            string title = epub.Title[0];

            //Get book authors (Every epub file can have multiple authors)
            string author = epub.Creator[0];

            //Get all book content as plain text
            string plainText = epub.GetContentAsPlainText();

            words = plainText.Split(delimiters, 1000);
        }

        private string[] words;
        private char[] delimiters = {' ','.',',' };

        public int WordCount
        {
            get
            {
                return 1000;
            }
        }

        public string this[int index]
        {
            get
            {
                return words[index];
            }
        }
    }
}
