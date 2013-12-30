using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextSources.UnitTests.ChapteredEPubTextSource_UnitTests
{
    [TestClass]
    public class WhenReadingTheTestDataFile
    {
        public ChapteredEPubTextSource EpubTextSource { get; set; }

        [TestInitialize]
        public void Init()
        {
            EpubTextSource = new ChapteredEPubTextSource("..\\..\\..\\TestData\\pragpub-2013-07.epub");
        }

        [TestMethod]
        public void ThenTheChapterCountIsCorrect()
        {
            Assert.AreEqual(15, EpubTextSource.ChapterCount);
        }

        [TestMethod]
        public void ThenTheTitleIsCorrect()
        {
            Assert.AreEqual("PragPub 2013-07: Issue #49", EpubTextSource.Title);
        }

        [TestMethod]
        public void ThenTheAuthorIsCorrect()
        {
            Assert.AreEqual("The Pragmatic Bookshelf", EpubTextSource.Author);
        }
    }
}
