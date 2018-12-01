using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day2;
using System.Collections.Generic;

namespace Day2Test
{
    [TestClass]
    public class Day2Test
    {
        CheckSum checker = new CheckSum();

        [TestMethod]
        public void differenceHighLow1()
        {
            double ergebnis = checker.getDifference("5	1	9	5");
            Assert.AreEqual(8, ergebnis);
        }

        [TestMethod]
        public void differenceHighLow2()
        {
            double ergebnis = checker.getDifference("7	5	3");
            Assert.AreEqual(4, ergebnis);
        }

        [TestMethod]
        public void differenceHighLow3()
        {
            double ergebnis = checker.getDifference("2	4	6	8");
            Assert.AreEqual(6, ergebnis);
        }

        [TestMethod]
        public void calculateSum()
        {
            List<string> liste = new List<string>() { "5	1	9	5", "7	5	3", "2	4	6	8" };
            double ergebnis = checker.calcSum(liste);
            Assert.AreEqual(18, ergebnis);
        }

        [TestMethod]
        public void evenDivision1()
        {
            double ergebnis = checker.evenDivision("5	9	2	8");
            Assert.AreEqual(4, ergebnis);
        }

        [TestMethod]
        public void evenDivision2()
        {
            double ergebnis = checker.evenDivision("9	4	7	3");
            Assert.AreEqual(3, ergebnis);
        }

        [TestMethod]
        public void evenDivision3()
        {
            double ergebnis = checker.evenDivision("3	8	6	5");
            Assert.AreEqual(2, ergebnis);
        }

        [TestMethod]
        public void calculateDivisionSum()
        {
            List<string> liste = new List<string>() { "5	9	2	8", "9	4	7	3", "3	8	6	5" };
            double ergebnis = checker.calcDivSum(liste);
            Assert.AreEqual(9, ergebnis);
        }
    }
}
