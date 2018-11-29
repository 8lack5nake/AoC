using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day1;

namespace Day1Test
{
    [TestClass]
    public class UnitTest1
    {
        Calculator calc = new Calculator();

        [TestMethod]
        public void EinzelneZahlen()
        {
            double ergebnis = calc.summUp("1234");
            Assert.AreEqual(0, ergebnis);
        }

        [TestMethod]
        public void FortFolgendeZahlen()
        {
            double ergebnis = calc.summUp("1122");
            Assert.AreEqual(3, ergebnis);
        }

        [TestMethod]
        public void AlleZahlen()
        {
            double ergebnis = calc.summUp("1111");
            Assert.AreEqual(4, ergebnis);
        }

        [TestMethod]
        public void ErsteUndLetzteZahl()
        {
            double ergebnis = calc.summUp("91212129");
            Assert.AreEqual(9, ergebnis);
        }

        [TestMethod]
        public void ErsterVergleich()
        {
            double ergebnis = calc.compareHalf("1212");
            Assert.AreEqual(6, ergebnis);
        }

        [TestMethod]
        public void ZweiterVergleich()
        {
            double ergebnis = calc.compareHalf("1221");
            Assert.AreEqual(0, ergebnis);
        }

        [TestMethod]
        public void DritterVergleich()
        {
            double ergebnis = calc.compareHalf("123425");
            Assert.AreEqual(4, ergebnis);
        }

        [TestMethod]
        public void VierterVergleich()
        {
            double ergebnis = calc.compareHalf("123123");
            Assert.AreEqual(12, ergebnis);
        }

        [TestMethod]
        public void fuenfterVergleich()
        {
            double ergebnis = calc.compareHalf("12131415");
            Assert.AreEqual(4, ergebnis);
        }
    }

}