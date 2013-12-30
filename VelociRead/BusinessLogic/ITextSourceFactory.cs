using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSources;

namespace VelociRead.BusinessLogic
{
    public interface ITextSourceFactory
    {
        ITextSource GetTextSource(string filename);
    }
}
