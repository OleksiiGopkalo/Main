using System;

namespace Lab5Library
{
    public class Lab2Processor
    {
        public static int CountAlmostPalindromicSubstrings(string s, int n, int k)
        {
            // Використовуємо реальну довжину рядка s, якщо передане n не збігається
            if (s == null || s.Length == 0)
            {
                throw new ArgumentException("Рядок не може бути порожнім.");
            }

            if (n != s.Length)
            {
                n = s.Length;
            }

            int count = 0;

            // Генеруємо всі можливі підстроки
            for (int start = 0; start < n; start++)
            {
                for (int end = start; end < n; end++)
                {
                    // Безпечне створення підстроки
                    if (end - start + 1 <= s.Length)
                    {
                        string substring = s.Substring(start, end - start + 1);
                        int changesRequired = CountChangesToMakePalindrome(substring);

                        if (changesRequired <= k)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        public static int CountChangesToMakePalindrome(string str)
        {
            if (str == null)
            {
                throw new ArgumentException("Рядок не може бути null.");
            }

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
}
