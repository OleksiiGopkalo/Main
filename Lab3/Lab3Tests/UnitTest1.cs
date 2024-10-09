using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void TestExample1()
    {
        char[,] maze = {
            { '.', '.', '.', '.', '.' },
            { '#', '.', '#', '.', '#' },
            { '.', '#', '.', '#', '.' },
            { '#', '.', '.', '.', '#' },
            { '.', '.', '.', '.', '.' }
        };
        int result = Program.CalculateVisibleArea(maze, 5);
        Assert.AreEqual(550, result);
    }

    [TestMethod]
    public void TestEmptyMaze()
    {
        char[,] maze = {
            { '.', '.', '.' },
            { '.', '.', '.' },
            { '.', '.', '.' }
        };
        int result = Program.CalculateVisibleArea(maze, 3);
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void TestFullWalls()
    {
        char[,] maze = {
            { '.', '#', '.' },
            { '#', '#', '#' },
            { '.', '#', '.' }
        };
        int result = Program.CalculateVisibleArea(maze, 3);
        Assert.AreEqual(200, result); // Дві видимі сторони у кожної стіни
    }

    [TestMethod]
    public void TestSingleWall()
    {
        char[,] maze = {
            { '.', '.', '.' },
            { '.', '#', '.' },
            { '.', '.', '.' }
        };
        int result = Program.CalculateVisibleArea(maze, 3);
        Assert.AreEqual(100, result); // Всі чотири сторони стіни видимі
    }

    [TestMethod]
    public void TestBorderWalls()
    {
        char[,] maze = {
            { '.', '#', '.' },
            { '#', '.', '#' },
            { '.', '#', '.' }
        };
        int result = Program.CalculateVisibleArea(maze, 3);
        Assert.AreEqual(300, result); // Три видимі сторони у кожної стіни
    }
}
