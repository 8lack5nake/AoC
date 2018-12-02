using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day2;

namespace Day2Test
{
    [TestClass]
    public class Day2Test
    {
        letterCounter counter = new letterCounter();

        [TestMethod]
        public void count1()
        {
            //double ergebnis = counter.countLetters("abcdef");
            //Assert.AreEqual(0, ergebnis);
        }

        [TestMethod]
        public void count2()
        {
            //double ergebnis = counter.countLetters("bababc");
            //Assert.AreEqual(3, ergebnis);
        }
    }
}
