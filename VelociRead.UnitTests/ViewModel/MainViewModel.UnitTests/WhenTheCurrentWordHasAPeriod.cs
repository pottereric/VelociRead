using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VelociRead.ViewModel;
using VelociRead.TestUtilities.Stubs;

namespace VelociRead.UnitTests.ViewModel_MainViewModel.UnitTests
{
    [TestClass]
    public class WhenTheCurrentWordHasAPeriod
    {
        MainViewModel viewModel = new MainViewModel(new TestTextSourceFactory(), new SingleWordAdvancer(), String.Empty);

        [TestInitialize]
        public void Init()
        {
            for (int i = 0; i < 9; i++)
            {
                viewModel.OnAdvance();
            }
        }

        [TestMethod]
        public void ThenThePeriodIsDisplayed()
        {
            Assert.AreEqual("ten.", viewModel.CurrentWord);
        }
    }
}
