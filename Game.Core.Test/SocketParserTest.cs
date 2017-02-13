using Game.Core.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Test
{
    [TestClass]
    public class SocketParserTest
    {
        [TestMethod]
        public void Chromatic()
        {
            var toTest = "RGB";

            var parser = new SocketParser();
            var config = parser.ParseSockets(toTest);

            Assert.AreEqual(3, config.MaxLinks);
            Assert.AreEqual("r", config.Links.First().Sockets.First().ToString());
            Assert.AreEqual("g", config.Links.First().Sockets.Skip(1).First().ToString());
            Assert.AreEqual("b", config.Links.First().Sockets.Skip(2).First().ToString());
            Assert.AreEqual("rgb", config.Links.First().ToString());
            Assert.AreEqual("rgb", config.ToString());
        }

        [TestMethod]
        public void Separated()
        {
            var toTest = "R G B";

            var parser = new SocketParser();
            var config = parser.ParseSockets(toTest);

            Assert.AreEqual(1, config.MaxLinks);
            Assert.AreEqual("r", config.Links.First().Sockets.First().ToString());
            Assert.AreEqual("g", config.Links.Skip(1).First().Sockets.First().ToString());
            Assert.AreEqual("b", config.Links.Skip(2).First().Sockets.First().ToString());
            Assert.AreEqual("r", config.Links.First().ToString());
            Assert.AreEqual("g", config.Links.Skip(1).First().ToString());
            Assert.AreEqual("b", config.Links.Skip(2).First().ToString());
            Assert.AreEqual("r g b", config.ToString());
        }

        [TestMethod]
        public void ThreeAndThree()
        {
            var toTest = "RGB BGR";

            var parser = new SocketParser();
            var config = parser.ParseSockets(toTest);

            Assert.AreEqual(3, config.MaxLinks);
            Assert.AreEqual("rgb bgr", config.ToString());
        }

        [TestMethod]
        public void FiveL()
        {
            var toTest = "RGBBG R";

            var parser = new SocketParser();
            var config = parser.ParseSockets(toTest);

            Assert.AreEqual(5, config.MaxLinks);
            Assert.AreEqual("rgbbg r", config.ToString());
        }

        [TestMethod]
        public void TheDream()
        {
            var toTest = "rgbbgr";

            var parser = new SocketParser();
            var config = parser.ParseSockets(toTest);

            Assert.AreEqual(6, config.MaxLinks);
            Assert.AreEqual("rgbbgr", config.ToString());
        }
    }
}
