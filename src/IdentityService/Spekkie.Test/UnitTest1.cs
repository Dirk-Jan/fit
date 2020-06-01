using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Spekkie.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("Oooweee deze test slaagt!");
            Assert.IsTrue(true);
        }
    }
}