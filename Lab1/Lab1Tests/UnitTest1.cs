using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lab1Tests
{
    [TestClass]
    public class DivisorTests
    {
        [TestInitialize]
        public void SetUp()
        {
            if (File.Exists("OUTPUT.TXT"))
            {
                File.Delete("OUTPUT.TXT");
            }
        }

        [TestMethod]
        public void TestSmallNumber()
        {
            File.WriteAllText("INPUT.TXT", "12");
            Program.Main(new string[0]); // Викликаємо Main
            string result = File.ReadAllText("OUTPUT.TXT");
            Assert.AreEqual("2,3,4,6,12", result.Trim()); // Очікуємо всі дільники
        }

        [TestMethod]
        public void TestPrimeNumber()
        {
            File.WriteAllText("INPUT.TXT", "13");
            Program.Main(new string[0]);
            string result = File.ReadAllText("OUTPUT.TXT");
            Assert.AreEqual("13", result.Trim()); // Прості числа мають лише себе як дільник
        }

        [TestMethod]
        public void TestCompositeNumberWithMultiplePrimeFactors()
        {
            File.WriteAllText("INPUT.TXT", "30");
            Program.Main(new string[0]);
            string result = File.ReadAllText("OUTPUT.TXT");
            Assert.AreEqual("2,3,5,6,10,15,30", result.Trim());
        }

        [TestMethod]
        public void TestLargeCompositeNumber()
        {
            File.WriteAllText("INPUT.TXT", "100");
            Program.Main(new string[0]);
            string result = File.ReadAllText("OUTPUT.TXT");
            Assert.AreEqual("2,4,5,10,20,25,50,100", result.Trim());
        }

        [TestMethod]
        public void TestSingleDigitNumber()
        {
            File.WriteAllText("INPUT.TXT", "7");
            Program.Main(new string[0]);
            string result = File.ReadAllText("OUTPUT.TXT");
            Assert.AreEqual("7", result.Trim());
        }
    }
}
