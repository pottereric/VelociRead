using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextSources.UnitTests.Chapter_UnitTests
{
    [TestClass]
    public class WhenUsingTenWords
    {
        public Chapter TestChapter { get; set; }

        [TestInitialize]
        public void Init()
        {
            var foo = "one two three four five six seven eight nine ten";
            TestChapter = new Chapter(foo);
        }

        [TestMethod]
        public void ThenTheWordCountIsCorrect()
        {
            Assert.AreEqual(10, TestChapter.WordCount);
        }

        [TestMethod]
        public void ThenTheIndexerWords()
        {
            Assert.AreEqual("six", TestChapter[5]);
        }
    }
}
