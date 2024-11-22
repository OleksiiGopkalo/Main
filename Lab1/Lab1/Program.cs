using System;
using System.Collections.Generic;
using System.IO;

namespace Lab1
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Run("/Users/aleksejgopkalo/Desktop/Main/Lab1/INPUT.TXT", "/Users/aleksejgopkalo/Desktop/Main/Lab1/OUTPUT.TXT");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unhandled exception: {ex.Message}");
            }
        }

        public static void Run(string inputFile, string outputFile) // Новий метод для виклику з інших проектів
        {
            if (!File.Exists(inputFile) || new FileInfo(inputFile).Length == 0)
            {
                Console.WriteLine($"Error: {inputFile} is missing or empty.");
                return;
            }

            string input = File.ReadAllText(inputFile).Trim();
            if (!long.TryParse(input, out long x) || x < 1)
            {
                Console.WriteLine("Error: Invalid input. Ensure the input file contains a valid natural number.");
                return;
            }

            List<long> divisors = GetDivisors(x); // Змінено для отримання всіх дільників
            File.WriteAllText(outputFile, string.Join(",", divisors)); // Записуємо всі дільники у файл
        }

        public static List<long> GetDivisors(long x) // Отримуємо всі дільники числа
        {
            List<long> divisors = new List<long>();

            for (long i = 1; i <= x; i++) // Перевірка всіх чисел до x
            {
                if (x % i == 0)
                {
                    divisors.Add(i); // Додаємо дільник
                }
            }

            return divisors;
        }
    }
}
