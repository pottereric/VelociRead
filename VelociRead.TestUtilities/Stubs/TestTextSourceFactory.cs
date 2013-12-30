using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextSources.TestUtilities.Stubs;
using VelociRead.BusinessLogic;

namespace VelociRead.TestUtilities.Stubs
{
    public class TestTextSourceFactory : ITextSourceFactory
    {
        public TextSources.ITextSource GetTextSource(string filename)
        {
            return new TextSourceStub();
        }
    }
}
