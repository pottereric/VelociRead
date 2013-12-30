using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VelociRead.ViewModel;
using VelociRead.TestUtilities.Stubs;

namespace VelociRead.UnitTests.ViewModel_MainViewModel.UnitTests
{
    [TestClass]
    public class WhenTheMainViewModelIsCreated
    {
        MainViewModel viewModel = new MainViewModel(new TestTextSourceFactory(), String.Empty);

        [TestInitialize]
        public void Init()
        {
        }

        [TestMethod]
        public void ThenTheFirstWordIsSelected()
        {
            Assert.AreEqual("One", viewModel.CurrentWord);
        }
    }
}
