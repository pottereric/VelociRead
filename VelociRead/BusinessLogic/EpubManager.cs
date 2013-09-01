using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSources;

namespace VelociRead.BusinessLogic
{
    public class EpubManager
    {
        private EpubManager() { }

        private static EpubManager _instance;
        public static EpubManager Instance
        {
            get { return _instance = _instance ?? new EpubManager(); }
        }

        public ITextSource CurrentTextSource { get; set; }

        public Chapter CurrentChapter { get; set; }
    }
}
