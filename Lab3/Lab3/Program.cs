using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        string[] lines = File.ReadAllLines("INPUT.TXT");
        
        int n = int.Parse(lines[0]);
        char[,] maze = new char[n, n];

        // Заповнення лабіринту
        for (int i = 0; i < n; i++)
        {
            string row = lines[i + 1];
            for (int j = 0; j < n; j++)
            {
                maze[i, j] = row[j];
            }
        }

        int totalVisibleArea = CalculateVisibleArea(maze, n);
        File.WriteAllText("OUTPUT.TXT", totalVisibleArea.ToString());
    }

    public static int CalculateVisibleArea(char[,] maze, int n)
    {
        int visibleArea = 0;
        int segmentSize = 5; // розмір сторони сегмента
        int wallHeight = 5; // висота стін

        // Перевірка всіх стін у лабіринті
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (maze[i, j] == '#')
                {
                    // Перевірка кожної сторони стіни
                    if (i > 0 && maze[i - 1, j] == '.') // Верхня сторона
                        visibleArea += segmentSize * wallHeight;
                    if (i < n - 1 && maze[i + 1, j] == '.') // Нижня сторона
                        visibleArea += segmentSize * wallHeight;
                    if (j > 0 && maze[i, j - 1] == '.') // Ліва сторона
                        visibleArea += segmentSize * wallHeight;
                    if (j < n - 1 && maze[i, j + 1] == '.') // Права сторона
                        visibleArea += segmentSize * wallHeight;
                }
            }
        }

        return visibleArea;
    }
}
