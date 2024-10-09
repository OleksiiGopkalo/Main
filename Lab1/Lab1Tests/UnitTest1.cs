using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        File.WriteAllText("INPUT.TXT", "12"); // Прості дільники: 2, 3
        Program.Main();
        string result = File.ReadAllText("OUTPUT.TXT");
        Assert.AreEqual("2", result); // Очікуємо 2 дільники (6 та 12)
    }

    [TestMethod]
    public void TestPrimeNumber()
    {
        File.WriteAllText("INPUT.TXT", "13"); // Прості дільники: 13
        Program.Main();
        string result = File.ReadAllText("OUTPUT.TXT");
        Assert.AreEqual("1", result); // Очікуємо 1 дільник (13)
    }

    [TestMethod]
    public void TestCompositeNumberWithMultiplePrimeFactors()
    {
        File.WriteAllText("INPUT.TXT", "30"); // Прості дільники: 2, 3, 5
        Program.Main();
        string result = File.ReadAllText("OUTPUT.TXT");
        Assert.AreEqual("1", result); // Очікуємо 1 дільник (30)
    }

 [TestMethod]
public void TestLargeCompositeNumber()
{
    File.WriteAllText("INPUT.TXT", "100"); // Прості дільники: 2, 5
    Program.Main();
    string result = File.ReadAllText("OUTPUT.TXT");
    Assert.AreEqual("3", result); // Очікуємо 3 дільники (20, 50, 100)
}
    [TestMethod]
    public void TestSingleDigitNumber()
    {
        File.WriteAllText("INPUT.TXT", "7"); // Прості дільники: 7
        Program.Main();
        string result = File.ReadAllText("OUTPUT.TXT");
        Assert.AreEqual("1", result); // Очікуємо 1 дільник (7)
    }
}
