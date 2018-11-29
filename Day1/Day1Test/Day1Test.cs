using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day1;

namespace Day1Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Calculator calc = new Calculator();
            //Assert.Equals();
            double ergebnis = calc.summUp("1122");
            Assert.AreEqual(0, ergebnis);
        }
    }

}