using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        try
        {
            // Зчитуємо всі рядки з файлу
            string[] lines = File.ReadAllLines("/Users/aleksejgopkalo/Desktop/Main/Lab3/INPUT.TXT");

            // Перевірка на те, чи є хоча б 1 рядок у файлі
            if (lines.Length == 0)
            {
                throw new InvalidDataException("Файл INPUT.TXT порожній.");
            }

            int n = int.Parse(lines[0]); // Розмір лабіринту
            char[,] maze = new char[n, n];

            // Заповнення лабіринту
            for (int i = 0; i < n; i++)
            {
                string row = lines[i + 1].Trim(); // Використовуємо Trim() для видалення зайвих пробілів
                if (row.Length != n)
                {
                    throw new InvalidDataException($"Рядок {i + 1} не має правильну довжину.");
                }

                for (int j = 0; j < n; j++)
                {
                    maze[i, j] = row[j];
                }
            }

            // Обчислюємо видиму площу
            int totalVisibleArea = CalculateVisibleArea(maze, n);

            // Запис результату в файл
            File.WriteAllText("/Users/aleksejgopkalo/Desktop/Main/Lab3/OUTPUT.TXT", totalVisibleArea.ToString());
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Помилка: Дані у файлі INPUT.TXT не відповідають очікуваному формату.");
        }
        catch (InvalidDataException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Невідома помилка: {ex.Message}");
        }
    }

    public static int CalculateVisibleArea(char[,] maze, int n)
    {
        int visibleArea = 0;
        int segmentSize = 5; // розмір сторони сегмента
        int wallHeight = 5; // висота стін
        int areaPerSide = segmentSize * wallHeight; // площа однієї сторони стіни

        // Перевірка всіх стін у лабіринті
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (maze[i, j] == '#')
                {
                    // Перевірка кожної сторони стіни
                    if (i > 0 && maze[i - 1, j] == '.') // Верхня сторона
                        visibleArea += areaPerSide;
                    if (i < n - 1 && maze[i + 1, j] == '.') // Нижня сторона
                        visibleArea += areaPerSide;
                    if (j > 0 && maze[i, j - 1] == '.') // Ліва сторона
                        visibleArea += areaPerSide;
                    if (j < n - 1 && maze[i, j + 1] == '.') // Права сторона
                        visibleArea += areaPerSide;
                }
            }
        }

        return visibleArea;
    }
}
