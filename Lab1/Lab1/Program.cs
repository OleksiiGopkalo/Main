﻿using System;
using System.Collections.Generic;
using System.IO;

public class Program // Зроблено public для доступу з інших проектів
{
    public static void Main()
    {
        try
        {
            Run("INPUT.TXT", "OUTPUT.TXT");
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

        List<long> primeDivisors = GetPrimeDivisors(x);
        long count = CountSpecialDivisors(x, primeDivisors);
        File.WriteAllText(outputFile, count.ToString());
    }

    public static List<long> GetPrimeDivisors(long x) // Зроблено public для тестування
    {
        List<long> primes = new List<long>();

        for (long i = 2; i * i <= x; i++)
        {
            if (x % i == 0)
            {
                bool isPrime = true;
                foreach (long p in primes)
                {
                    if (i % p == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(i);
                    while (x % i == 0)
                        x /= i;
                }
            }
        }

        if (x > 1)
        {
            primes.Add(x);
        }

        return primes;
    }

    public static long CountSpecialDivisors(long x, List<long> primes) // Зроблено public для тестування
    {
        long count = 0;

        for (long i = 1; i * i <= x; i++)
        {
            if (x % i == 0)
            {
                if (IsDivisibleByAllPrimes(i, primes))
                {
                    count++;
                }
                long otherDivisor = x / i;
                if (otherDivisor != i && IsDivisibleByAllPrimes(otherDivisor, primes))
                {
                    count++;
                }
            }
        }

        return count;
    }

    public static bool IsDivisibleByAllPrimes(long number, List<long> primes) // Зроблено public для тестування
    {
        foreach (long prime in primes)
        {
            if (number % prime != 0)
            {
                return false;
            }
        }
        return true;
    }
}
