var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Додаємо підтримку сесій
builder.Services.AddDistributedMemoryCache(); // Використовуємо пам'ять для збереження сесій
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Тривалість сесії
    options.Cookie.HttpOnly = true; // Забезпечення безпеки кукі (захищає від доступу до кукі через JS)
    options.Cookie.IsEssential = true; // Сесії є критично необхідними для роботи додатка
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Включення HSTS (захист HTTPS)
}

app.UseHttpsRedirection(); // Автоматичне перенаправлення на HTTPS
app.UseStaticFiles(); // Доступ до статичних файлів (CSS, JS, зображення)

app.UseRouting(); // Налаштування маршрутизації

// Використання сесій (обов'язково після UseRouting)
app.UseSession();

app.UseAuthorization(); // Використання авторизації

// Налаштування маршруту за замовчуванням (відкривається Lab2)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Lab}/{action=Lab2}/{id?}");

app.Run();
