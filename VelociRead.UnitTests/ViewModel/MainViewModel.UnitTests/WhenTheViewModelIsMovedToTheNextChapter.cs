using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VelociRead.ViewModel;
using VelociRead.TestUtilities.Stubs;

namespace VelociRead.UnitTests.ViewModel_MainViewModel.UnitTests
{
    [TestClass]
    public class WhenTheViewModelIsMovedToTheNextChapter
    {
        MainViewModel viewModel = new MainViewModel(new TestTextSourceFactory(), new SingleWordAdvancer(), String.Empty);

        [TestInitialize]
        public void Init()
        {
            viewModel.MoveToNextIndex();
            viewModel.OnNextChapter();
        }

        [TestMethod]
        public void ThenTheFirstWordOfTHeNextChapterIsDisplayed()
        {
            Assert.AreEqual("Chapter2One", viewModel.CurrentWord);
        }
    }
}
