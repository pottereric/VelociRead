using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VelociRead.ViewModel;
using VelociRead.TestUtilities.Stubs;

namespace VelociRead.UnitTests.ViewModel_MainViewModel.UnitTests
{
    [TestClass]
    public class WhenTheViewModelJumpsBackAndTheIndexIsLessThan50
    {
        MainViewModel viewModel = new MainViewModel(new TestTextSourceFactory(), new SingleWordAdvancer(), String.Empty);

        [TestInitialize]
        public void Init()
        {
            for (int i = 0; i < 10; i++)
            {
                viewModel.OnAdvance();
            }
            viewModel.OnJumpBack();
        }

        [TestMethod]
        public void ThenTheCurrentWordWillBeTheFirstWordInTheChapter()
        {
            Assert.AreEqual("One", viewModel.CurrentWord);
        }
    }
}
