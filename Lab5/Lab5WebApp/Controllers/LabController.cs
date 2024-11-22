using Microsoft.AspNetCore.Mvc;
using Lab5Library;

namespace Lab5WebApp.Controllers
{
    public class LabController : Controller
    {
        [HttpGet]
        public IActionResult Lab2()
        {
            return View(); // Переконайтеся, що це View існує
        }

[HttpPost]
public IActionResult Lab2(IFormFile? inputFile)
{
    try
    {
        string inputContent;

        // Якщо файл не завантажено, використовуємо стандартний `INPUT.TXT` з кореня проекту
        if (inputFile == null || inputFile.Length == 0)
        {
            string defaultInputPath = Path.Combine(Directory.GetCurrentDirectory(), "../INPUT.TXT");
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

        // Обробляємо вміст
        string[] inputLines = inputContent.Split('\n');
        string[] parameters = inputLines[0].Split();
        int n = int.Parse(parameters[0]);
        int k = int.Parse(parameters[1]);
        string s = inputLines[1].Trim();

        // Викликаємо метод із бібліотеки
        int result = Lab2Processor.CountAlmostPalindromicSubstrings(s, n, k);

        // Генеруємо файл OUTPUT.TXT
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "../OUTPUT.TXT");
        System.IO.File.WriteAllText(outputPath, result.ToString());

        // Виводимо результат у View
        ViewBag.Result = result;
        ViewBag.OutputFilePath = "/OUTPUT.TXT"; // Посилання для завантаження результату
    }
    catch (Exception ex)
    {
        ViewBag.Error = "Сталася помилка: " + ex.Message;
    }

    return View();
}


    }
}
