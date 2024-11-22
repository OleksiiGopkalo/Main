using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab1; // Додаємо простір імен Lab1

namespace Lab1Tests
{
    [TestClass]
    public class DivisorTests
    {
        private string inputFilePath = "/Users/aleksejgopkalo/Desktop/Main/Lab1/INPUT.TXT";
        private string outputFilePath = "/Users/aleksejgopkalo/Desktop/Main/Lab1/OUTPUT.TXT";

        [TestInitialize]
        public void SetUp()
        {
            if (File.Exists(inputFilePath))
                File.Delete(inputFilePath);
            if (File.Exists(outputFilePath))
                File.Delete(outputFilePath);
        }

        [TestMethod]
        public void TestSmallNumber()
        {
            File.WriteAllText(inputFilePath, "12");
            Program.Run(inputFilePath, outputFilePath); // Викликаємо Program.Run
            string result = File.ReadAllText(outputFilePath);
            Assert.AreEqual("1,2,3,4,6,12", result.Trim());
        }

        [TestMethod]
        public void TestPrimeNumber()
        {
            File.WriteAllText(inputFilePath, "13");
            Program.Run(inputFilePath, outputFilePath);
            string result = File.ReadAllText(outputFilePath);
            Assert.AreEqual("1,13", result.Trim());
        }

        [TestMethod]
        public void TestCompositeNumberWithMultiplePrimeFactors()
        {
            File.WriteAllText(inputFilePath, "30");
            Program.Run(inputFilePath, outputFilePath);
            string result = File.ReadAllText(outputFilePath);
            Assert.AreEqual("1,2,3,5,6,10,15,30", result.Trim());
        }

        [TestMethod]
        public void TestLargeCompositeNumber()
        {
            File.WriteAllText(inputFilePath, "100");
            Program.Run(inputFilePath, outputFilePath);
            string result = File.ReadAllText(outputFilePath);
            Assert.AreEqual("1,2,4,5,10,20,25,50,100", result.Trim());
        }

        [TestMethod]
        public void TestSingleDigitNumber()
        {
            File.WriteAllText(inputFilePath, "7");
            Program.Run(inputFilePath, outputFilePath);
            string result = File.ReadAllText(outputFilePath);
            Assert.AreEqual("1,7", result.Trim());
        }
    }
}
