using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelociRead.BusinessLogic;

namespace VelociRead.TestUtilities.Stubs
{
    public class SingleWordAdvancer : IWordAdvancer
    {
        public ViewModel.MainViewModel ViewModel { get; set; }

        public void Initialize()
        {
            
        }

        public void Advance()
        {
            ViewModel.MoveToNextIndex();
        }
    }
}
