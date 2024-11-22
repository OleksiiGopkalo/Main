using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Lab5WebApp.Controllers
{
    public class AccountController : Controller
    {
        // Сховище для збереження зареєстрованих користувачів (для демонстрації)
        private static Dictionary<string, (string Password, string FullName, string Phone, string Email)> RegisteredUsers =
            new Dictionary<string, (string Password, string FullName, string Phone, string Email)>();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Перевірка, чи існує користувач у системі
            if (RegisteredUsers.TryGetValue(username, out var userInfo) && userInfo.Password == password)
            {
                // Збереження імені користувача у сесії
                HttpContext.Session.SetString("User", username);
                return RedirectToAction("Profile");
            }

            ViewBag.Error = "Невірний логін або пароль.";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string fullName, string password, string confirmPassword, string phone, string email)
        {
            // Перевірка унікальності імені користувача
            if (RegisteredUsers.ContainsKey(username))
            {
                ViewBag.Error = "Користувач із таким іменем вже існує.";
                return View();
            }

            // Перевірка паролю
            if (password != confirmPassword)
            {
                ViewBag.Error = "Паролі не співпадають.";
                return View();
            }

            if (!Regex.IsMatch(password, @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&#])[A-Za-z\d@$!%*?&#]{8,16}$"))
            {
                ViewBag.Error = "Пароль має містити від 8 до 16 символів, щонайменше одну велику літеру, одну цифру та один спеціальний символ.";
                return View();
            }

            // Перевірка формату телефону
            if (!Regex.IsMatch(phone, @"^\+380\d{9}$"))
            {
                ViewBag.Error = "Телефон має бути у форматі +380XXXXXXXXX.";
                return View();
            }

            // Перевірка формату електронної адреси
            if (!Regex.IsMatch(email, @"^[^\s@]+@[^\s@]+\.[^\s@]+$"))
            {
                ViewBag.Error = "Електронна адреса має неправильний формат.";
                return View();
            }

            // Додавання користувача до "бази даних"
            RegisteredUsers[username] = (Password: password, FullName: fullName, Phone: phone, Email: email);

            // Збереження імені користувача у сесії після реєстрації
            HttpContext.Session.SetString("User", username);
            return RedirectToAction("Profile");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            // Перевірка авторизації
            string? username = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login");
            }

            // Виведення даних користувача
            if (RegisteredUsers.TryGetValue(username, out var userInfo))
            {
                ViewBag.User = username;
                ViewBag.FullName = userInfo.FullName;
                ViewBag.Phone = userInfo.Phone;
                ViewBag.Email = userInfo.Email;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            // Очищення сесії для виходу з системи
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
