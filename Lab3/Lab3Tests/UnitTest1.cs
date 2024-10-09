using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void TestSimpleMaze()
    {
        // Простий лабіринт 3x3 з однією стіною посередині
        char[,] maze = {
            { '.', '.', '.' },
            { '.', '#', '.' },
            { '.', '.', '.' }
        };
        int result = Program.CalculateVisibleArea(maze, 3);
        Assert.AreEqual(100, result); // Всі 4 сторони стіни видимі, загальна площа 100 кв. м.
    }

    [TestMethod]
    public void TestAllWalls()
    {
        // Лабіринт 3x3, де всі сегменти — це стіни
        char[,] maze = {
            { '#', '#', '#' },
            { '#', '#', '#' },
            { '#', '#', '#' }
        };
        int result = Program.CalculateVisibleArea(maze, 3);
        Assert.AreEqual(0, result); // Усі сторони стін заблоковані іншими стінами, видимих сторін немає
    }

    [TestMethod]
    public void TestWallsWithGaps()
    {
        // Лабіринт 3x3 з чергуванням стін і порожніх клітин
        char[,] maze = {
            { '#', '.', '#' },
            { '.', '#', '.' },
            { '#', '.', '#' }
        };
        int result = Program.CalculateVisibleArea(maze, 3);
        Assert.AreEqual(300, result); // Кожна стіна має тільки 2 видимі сторони, загальна площа 300 кв. м.
    }

    [TestMethod]
    public void TestMazeWithBorderWalls()
    {
        // Лабіринт 4x4 з порожніми клітинами всередині та стінами на межах
        char[,] maze = {
            { '#', '#', '#', '#' },
            { '#', '.', '.', '#' },
            { '#', '.', '.', '#' },
            { '#', '#', '#', '#' }
        };
        int result = Program.CalculateVisibleArea(maze, 4);
        Assert.AreEqual(200, result); // Лише 4 сторони внутрішніх стін видимі, кожна має площу 50 кв. м.
    }

    [TestMethod]
    public void TestLargerMaze()
    {
        // Більший лабіринт 5x5 із випадковим розташуванням стін і порожніх клітин
        char[,] maze = {
            { '.', '#', '.', '#', '.' },
            { '#', '#', '.', '#', '#' },
            { '.', '.', '#', '.', '.' },
            { '#', '#', '.', '#', '#' },
            { '.', '#', '.', '#', '.' }
        };
        int result = Program.CalculateVisibleArea(maze, 5);
        Assert.AreEqual(700, result); // Перерахована площа видимих сторін
    }
}
