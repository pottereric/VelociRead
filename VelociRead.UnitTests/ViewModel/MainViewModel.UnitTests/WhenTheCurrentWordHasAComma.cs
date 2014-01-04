using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VelociRead.ViewModel;
using VelociRead.TestUtilities.Stubs;

namespace VelociRead.UnitTests.ViewModel_MainViewModel.UnitTests
{
    [TestClass]
    public class WhenTheCurrentWordHasAComma
    {
        MainViewModel viewModel = new MainViewModel(new TestTextSourceFactory(), new SingleWordAdvancer(), String.Empty);

        [TestInitialize]
        public void Init()
        {
            for (int i = 0; i < 3; i++)
            {
                viewModel.OnAdvance();
            }
        }

        [TestMethod]
        public void ThenTheCommaIsDisplayed()
        {
            Assert.AreEqual("four,", viewModel.CurrentWord);
        }
    }
}
