using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VelociRead.ViewModel;
using VelociRead.TestUtilities.Stubs;

namespace VelociRead.UnitTests.ViewModel_MainViewModel.UnitTests
{
    [TestClass]
    public class WhenTheViewModelJumpsBackAndTheIndexIsMoreThan50
    {
        MainViewModel viewModel = new MainViewModel(new TestTextSourceFactory(), new SingleWordAdvancer(), String.Empty);

        [TestInitialize]
        public void Init()
        {
            for (int i = 0; i < 57; i++)
            {
                viewModel.OnAdvance();
            }
            viewModel.OnJumpBack();
        }

        [TestMethod]
        public void ThenTheIndexShouldJumpBack50Words()
        {
            Assert.AreEqual("eight", viewModel.CurrentWord);
        }
    }
}
