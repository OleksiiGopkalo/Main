using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        string[] input = File.ReadAllLines("/Users/aleksejgopkalo/Desktop/Main/Lab2/INPUT.TXT");
        string[] parameters = input[0].Split();
        
        int n = int.Parse(parameters[0]);
        int k = int.Parse(parameters[1]);
        string s = input[1];

        int result = CountAlmostPalindromicSubstrings(s, n, k);
        File.WriteAllText("/Users/aleksejgopkalo/Desktop/Main/Lab2/OUTPUT.TXT", result.ToString());
    }

    public static int CountAlmostPalindromicSubstrings(string s, int n, int k)
    {
        int count = 0;

        // Генеруємо всі можливі підслів'я
        for (int start = 0; start < n; start++)
        {
            for (int end = start; end < n; end++)
            {
                string substring = s.Substring(start, end - start + 1);
                int changesRequired = CountChangesToMakePalindrome(substring);
                
                if (changesRequired <= k)
                {
                    count++;
                }
            }
        }

        return count;
    }

    public static int CountChangesToMakePalindrome(string str)
    {
        int changes = 0;
        int len = str.Length;
        
        for (int i = 0; i < len / 2; i++)
        {
            if (str[i] != str[len - i - 1])
            {
                changes++;
            }
        }

        return changes;
    }
}
