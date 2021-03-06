namespace FantasticWorderTests
{
    using FantasticWorder;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;

    [TestClass]
    public class WorderTests
    {
        protected Worder Worder { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            this.Worder = new Worder();
        }

        [TestMethod]
        public void WordateTransformsFromSameToCost()
        {
            var result = this.Worder.Wordate("same", "cost", new System.Collections.Generic.List<string> { "same", "came", "case", "cast", "cost" });

            Assert.AreEqual("same", result.First());
            Assert.AreEqual("came", result.Skip(1).First());
            Assert.AreEqual("case", result.Skip(2).First());
            Assert.AreEqual("cast", result.Skip(3).First());
            Assert.AreEqual("cost", result.Last());
        }

        [TestMethod]
        public void WordateTransformsFromSpinToSpot()
        {
            var result = this.Worder.Wordate("spin", "spot", new System.Collections.Generic.List<string> { "spin", "spit", "spat", "spot", "span" });

            Assert.AreEqual("spin", result.First());
            Assert.AreEqual("spit", result.Skip(1).First());
            Assert.AreEqual("spot", result.Last());
        }
    }
}
