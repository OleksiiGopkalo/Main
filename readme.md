### Кросс-платформене програмування

## Гопкало Олексій Володимирович, група ІПЗ-34мс (Варіант №15)

Цей проект містить лабораторні роботи для кросплатформенного середовища з використанням .NET Core 8.0. Він використовує `dotnet msbuild` для побудови, тестування та запуску кожної лабораторної роботи.

## Встановлення

1. Завантажте та встановіть [SDK .NET Core](https://dotnet.microsoft.com/download).
2. Клонуйте цей репозиторій:
   ```bash
   git clone https://github.com/OleksiiGopkalo/Main.git
1. Тестування лабораторної роботи(N - номер лр):
   ```bash
   dotnet msbuild build.proj /p:Solution=labN /t:Test

2. Запуск лабораторної роботи(N - номер лр):
   ```bash
   dotnet msbuild build.proj /p:Solution=labN /t:Run

3. Збірка лабораторної роботи(N - номер лр):
   ```bash
   dotnet msbuild build.proj /p:Solution=labN /t:Build