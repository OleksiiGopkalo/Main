using System;
using System.IO;
using Lab4Library;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            PrintHelp();
            return;
        }

        switch (args[0].ToLower())
        {
            case "version":
                Console.WriteLine("Lab4 Application");
                Console.WriteLine("Author: Гопкало Олексій Володимирович");
                Console.WriteLine("Version: 1.0.0");
                break;

            case "run":
                if (args.Length < 2)
                {
                    Console.WriteLine("Error: Specify a lab to run (lab1).");
                    return;
                }

                string labToRun = args[1].ToLower();
                string inputFile = GetFilePath(args, "-i", "--input");
                string outputFile = GetFilePath(args, "-o", "--output");

                try
                {
                    switch (labToRun)
                    {
                        case "lab1":
                            LabRunner.Lab1(inputFile, outputFile);
                            Console.WriteLine($"Lab1 executed. Output written to {outputFile}");
                            break;

                        default:
                            Console.WriteLine("Error: Unknown lab. Available options: lab1.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                break;

            case "set-path":
                if (args.Length < 3 || (args[1] != "-p" && args[1] != "--path"))
                {
                    Console.WriteLine("Error: Please specify a valid path using -p or --path.");
                    return;
                }

                string path = args[2];
                if (Directory.Exists(path))
                {
                    Environment.SetEnvironmentVariable("LAB_PATH", path);
                    Console.WriteLine($"LAB_PATH set to: {path}");
                }
                else
                {
                    Console.WriteLine($"Error: Directory '{path}' does not exist.");
                }
                break;

            default:
                Console.WriteLine("Invalid command.");
                PrintHelp();
                break;
        }
    }

    static void PrintHelp()
    {
        Console.WriteLine("Usage:");
        Console.WriteLine("  version - Show application version and author.");
        Console.WriteLine("  run <lab1> [-i <input>] [-o <output>] - Run specified lab.");
        Console.WriteLine("  set-path -p <path> - Set default path for input and output files.");
    }

    static string GetFilePath(string[] args, string shortOpt, string longOpt)
    {
        // 1. Перевірка параметрів командного рядка
        for (int i = 0; i < args.Length - 1; i++)
        {
            if (args[i] == shortOpt || args[i] == longOpt)
            {
                return args[i + 1];
            }
        }

        // 2. Перевірка змінної середовища LAB_PATH
        string labPath = Environment.GetEnvironmentVariable("LAB_PATH") ?? string.Empty;
        if (!string.IsNullOrEmpty(labPath))
        {
            string fileName = shortOpt == "-i" ? "INPUT.TXT" : "OUTPUT.TXT";
            return Path.Combine(labPath, fileName);
        }

        // 3. Домашня директорія за замовчуванням
        return Path.Combine("/Users/aleksejgopkalo/Desktop/Main/Lab4", shortOpt == "-i" ? "INPUT.TXT" : "OUTPUT.TXT");
    }
}
