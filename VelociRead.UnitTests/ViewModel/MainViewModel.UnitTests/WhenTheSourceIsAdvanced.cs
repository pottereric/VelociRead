using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VelociRead.ViewModel;
using VelociRead.TestUtilities.Stubs;

namespace VelociRead.UnitTests.ViewModel_MainViewModel.UnitTests
{
    [TestClass]
    public class WhenTheSourceIsAdvanced
    {
        MainViewModel viewModel = new MainViewModel(new TestTextSourceFactory(), String.Empty);

        [TestInitialize]
        public void Init()
        {
            viewModel.OnAdvance();
        }

        [TestMethod]
        public void ThenTheCurrentWordHasMovedPastTheFirstWord()
        {
            Assert.AreNotEqual("One", viewModel.CurrentWord);
        }

        // CurrentWPM
        
    }
}
