namespace FantasticWorderTests
{
    using FantasticWorder;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Linq;

    [TestClass]
    public class DictionaryReaderTests
    {
        protected Mock<IFileReader> File { get; set; }

        protected DictionaryReader Dictionary { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            this.File = new Mock<IFileReader>();

            this.Dictionary = new DictionaryReader(File.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            this.File.VerifyAll();
        }

        [TestMethod]
        public void ReadIgnoresLessThanFourLetterWords()
        {
            this.File.Setup(s => s.Read(@"words-english.txt")).Returns(new string[] { "Turn", "it", "down", "you", "say", "But", "all", "I", "got", "to", "say", "to", "you", "is", "time", "and", "time", "again", "I", "say", "No!", "No!", "No!", "No!", "Tell", "me", "not", "to", "play", "Well", "all", "I", "got", "to", "say", "to", "when", "you", "tell", "me", "not", "to", "play", "I", "say", "No!", "No!", "No!", "No!", "So", "if", "you", "ask", "me", "why", "I", "like", "the", "way", "I", "play", "it", "There's", "only", "one", "thing", "I", "can", "say", "to", "you", "I", "wanna", "rock!", "(Rock!)" });

            var words = this.Dictionary.Read();

            Assert.IsFalse(words.Any(a => a.Length < 4));
        }
    }
}
