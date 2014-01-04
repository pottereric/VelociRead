using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VelociRead.ViewModel;
using VelociRead.TestUtilities.Stubs;

namespace VelociRead.UnitTests.ViewModel_MainViewModel.UnitTests
{
    [TestClass]
    public class WhenTheViewModelIsMovedToThePreviousChapter
    {
        MainViewModel viewModel = new MainViewModel(new TestTextSourceFactory(), new SingleWordAdvancer(), String.Empty);

        [TestInitialize]
        public void Init()
        {
            viewModel.OnNextChapter();
            viewModel.OnNextChapter();
        }

        [TestMethod]
        public void ThenTheCurrentChapterIsMovedBackOne()
        {
            Assert.AreEqual("Chapter3One", viewModel.CurrentWord);
            viewModel.OnPreviousChapter();
            Assert.AreEqual("Chapter2One", viewModel.CurrentWord);

        }
    }
}
