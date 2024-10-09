using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void TestExample1()
    {
        string s = "abcde";
        int n = 5, k = 1;
        int result = Program.CountAlmostPalindromicSubstrings(s, n, k);
        Assert.AreEqual(12, result);
    }

    [TestMethod]
    public void TestExample2()
    {
        string s = "aaa";
        int n = 3, k = 3;
        int result = Program.CountAlmostPalindromicSubstrings(s, n, k);
        Assert.AreEqual(6, result);
    }

    [TestMethod]
    public void TestSingleCharacter()
    {
        string s = "a";
        int n = 1, k = 0;
        int result = Program.CountAlmostPalindromicSubstrings(s, n, k);
        Assert.AreEqual(1, result); // Лише одна підстрока "a" і вона вже паліндром
    }

    [TestMethod]
    public void TestAllSameCharacters()
    {
        string s = "aaaa";
        int n = 4, k = 0;
        int result = Program.CountAlmostPalindromicSubstrings(s, n, k);
        Assert.AreEqual(10, result); // Усі підстроки вже є паліндромами
    }

    [TestMethod]
    public void TestMaximumK()
    {
        string s = "abcd";
        int n = 4, k = 2;
        int result = Program.CountAlmostPalindromicSubstrings(s, n, k);
        Assert.AreEqual(10, result); // Усі підстроки можна перетворити на паліндроми з K = 2
    }
}
