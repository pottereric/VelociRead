using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSources
{
    public class Chapter
    {
        public Chapter(string text)
        {
            words = text.Split(delimiters);
        }

        private string[] words;
        private char[] delimiters = { ' ', '.', ',' };

        public int WordCount
        {
            get
            {
                return words.Count();
            }
        }

        public string this[int index]
        {
            get
            {
                if (index < words.Count())
                {
                    return words[index];
                }
                else
                {
                    return "// finished";
                }
            }
        }

        public string Title
        {
            get
            {
                return String.Join(" ", words.Where(s => !String.IsNullOrWhiteSpace(s)).Take(10).ToArray());
            }
        }
    }
}
