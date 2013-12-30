using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelociRead.ViewModel;

namespace VelociRead.BusinessLogic
{
    public interface IWordAdvancer
    {
        MainViewModel ViewModel { get; set; }
        void Initialize();
        void Advance();
    }
}
