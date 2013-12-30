using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSources;

namespace VelociRead.BusinessLogic
{
    public class TextSourceFactory : ITextSourceFactory
    {
        public ITextSource GetTextSource(string filename)
        {
            return new ChapteredEPubTextSource(filename);
        }
    }
}
