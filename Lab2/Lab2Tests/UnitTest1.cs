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
            // Якщо файл OUTPUT.TXT існує, видаляємо його перед кожним тестом
            if (File.Exists("OUTPUT.TXT"))
            {
                File.Delete("OUTPUT.TXT");
            }
        }

        [TestMethod]
        public void TestSmallNumber()
        {
            // Записуємо тестові дані в INPUT.TXT
            File.WriteAllText("INPUT.TXT", "12");

            // Викликаємо Main (який в свою чергу викликає Run)
            Program.Main();

            // Зчитуємо результат з OUTPUT.TXT
            string result = File.ReadAllText("OUTPUT.TXT");

            // Очікуємо правильний результат: всі дільники числа 12
            Assert.AreEqual("2,3,4,6,12", result.Trim());
        }

        [TestMethod]
        public void TestPrimeNumber()
        {
            // Тест для простого числа
            File.WriteAllText("INPUT.TXT", "13");
            Program.Main(); // Викликаємо Main
            string result = File.ReadAllText("OUTPUT.TXT");
            Assert.AreEqual("13", result.Trim()); // Для простого числа результатом буде саме число
        }

        [TestMethod]
        public void TestCompositeNumberWithMultiplePrimeFactors()
        {
            // Тест для числа з кількома простими дільниками
            File.WriteAllText("INPUT.TXT", "30");
            Program.Main();
            string result = File.ReadAllText("OUTPUT.TXT");
            Assert.AreEqual("2,3,5,6,10,15,30", result.Trim());
        }

        [TestMethod]
        public void TestLargeCompositeNumber()
        {
            // Тест для великого складного числа
            File.WriteAllText("INPUT.TXT", "100");
            Program.Main();
            string result = File.ReadAllText("OUTPUT.TXT");
            Assert.AreEqual("2,4,5,10,20,25,50,100", result.Trim());
        }

        [TestMethod]
        public void TestSingleDigitNumber()
        {
            // Тест для числа з одним дільником
            File.WriteAllText("INPUT.TXT", "7");
            Program.Main();
            string result = File.ReadAllText("OUTPUT.TXT");
            Assert.AreEqual("7", result.Trim());
        }
    }
}
