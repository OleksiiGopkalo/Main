using Microsoft.AspNetCore.Mvc;
using Lab5Library; // Підключення бібліотеки
using System.IO;

namespace Lab5WebApp.Controllers
{
    public class LabController : Controller
    {
        [HttpGet]
        public IActionResult Lab2()
        {
            // Перевірка авторизації через Session
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Lab2(IFormFile? inputFile)
        {
            // Перевірка авторизації через Session
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            try
            {
                string inputContent;

                // Якщо файл не завантажено, використовуємо стандартний INPUT.TXT
                if (inputFile == null || inputFile.Length == 0)
                {
                    string defaultInputPath = Path.Combine(Directory.GetCurrentDirectory(), "INPUT.TXT");
                    if (!System.IO.File.Exists(defaultInputPath))
                    {
                        throw new FileNotFoundException("Файл INPUT.TXT не знайдено.");
                    }
                    inputContent = System.IO.File.ReadAllText(defaultInputPath);
                }
                else
                {
                    // Зчитуємо завантажений файл
                    using (var reader = new StreamReader(inputFile.OpenReadStream()))
                    {
                        inputContent = reader.ReadToEnd();
                    }
                }

                // Перевірка на порожній файл
                if (string.IsNullOrWhiteSpace(inputContent))
                {
                    throw new ArgumentException("Файл INPUT.TXT є порожнім.");
                }

                // Обробка даних
                string[] inputLines = inputContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);

                // Перевірка структури файлу
                if (inputLines.Length < 2)
                {
                    throw new ArgumentException("Файл INPUT.TXT має неправильну структуру.");
                }

                string[] parameters = inputLines[0].Split();
                if (parameters.Length < 2)
                {
                    throw new ArgumentException("Файл INPUT.TXT має неправильний формат у першому рядку.");
                }

                int n = int.Parse(parameters[0]);
                int k = int.Parse(parameters[1]);
                string s = inputLines[1].Trim();

                // Перевірка, чи рядок не порожній
                if (string.IsNullOrEmpty(s))
                {
                    throw new ArgumentException("Рядок не може бути порожнім.");
                }

                // Виклик методу з бібліотеки
                int result = Lab2Processor.CountAlmostPalindromicSubstrings(s, n, k);

                // Запис результату в OUTPUT.TXT
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "OUTPUT.TXT");
                System.IO.File.WriteAllText(outputPath, result.ToString());

                // Вивід результату у View
                ViewBag.Result = result;
                ViewBag.OutputFilePath = "/OUTPUT.TXT";
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Сталася помилка: " + ex.Message;
            }

            return View();
        }
    }
}
