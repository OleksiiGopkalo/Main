using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Check if INPUT.TXT exists and is not empty
            if (!File.Exists("INPUT.TXT") || new FileInfo("INPUT.TXT").Length == 0)
            {
                Console.WriteLine("Error: INPUT.TXT is missing or empty.");
                return;
            }

            // Read the input and attempt to parse it
            string input = File.ReadAllText("INPUT.TXT").Trim();
            if (!long.TryParse(input, out long x) || x < 1)
            {
                Console.WriteLine("Error: Invalid input. Ensure INPUT.TXT contains a valid natural number.");
                return;
            }

            // Get the prime divisors of x
            List<long> primeDivisors = GetPrimeDivisors(x);

            // Calculate the count of divisors meeting the conditions
            long count = CountSpecialDivisors(x, primeDivisors);

            // Write the result to the output file
            File.WriteAllText("OUTPUT.TXT", count.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unhandled exception: {ex.Message}");
        }
    }

    // Function to find prime divisors of x
    static List<long> GetPrimeDivisors(long x)
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

    // Function to count divisors of x divisible by each of its prime divisors
    static long CountSpecialDivisors(long x, List<long> primes)
    {
        long count = 0;
        
        // Iterate through all divisors and check conditions
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

    // Function to check if a number is divisible by all elements in a list
    static bool IsDivisibleByAllPrimes(long number, List<long> primes)
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
