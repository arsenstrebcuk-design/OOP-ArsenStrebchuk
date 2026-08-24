using lab7v18;
using System.Net.Http;

Console.OutputEncoding = System.Text.Encoding.UTF8;

FileProcessor fileProcessor = new FileProcessor();
NetworkClient networkClient = new NetworkClient();

// shouldRetry: повторювати лише для IOException та HttpRequestException
Func<Exception, bool> shouldRetry = ex =>
    ex is IOException || ex is HttpRequestException;


Console.WriteLine("=== Сценарій 1: Збереження кешу (FileProcessor.SaveCache) ===");
Console.WriteLine("Очікується IOException перші 4 рази, потім успіх.\n");

try
{
    RetryHelper.ExecuteWithRetry<bool>(
        () => { fileProcessor.SaveCache("cache/data.bin", "cached-payload"); return true; },
        retryCount: 6,
        initialDelay: TimeSpan.FromMilliseconds(100),
        shouldRetry: shouldRetry);

    Console.WriteLine("Результат: збереження кешу завершилось успішно.\n");
}
catch (Exception ex)
{
    Console.WriteLine($"Результат: збереження кешу провалилось — {ex.Message}\n");
}


Console.WriteLine("=== Сценарій 2: Вивантаження кешу (NetworkClient.UploadCache) ===");
Console.WriteLine("Очікується HttpRequestException перші 2 рази, потім успіх.\n");

try
{
    bool ok = RetryHelper.ExecuteWithRetry<bool>(
        () => networkClient.UploadCache("https://api.example.com/cache", "cached-payload"),
        retryCount: 4,
        initialDelay: TimeSpan.FromMilliseconds(100),
        shouldRetry: shouldRetry);

    Console.WriteLine($"Результат: вивантаження кешу = {ok}.\n");
}
catch (Exception ex)
{
    Console.WriteLine($"Результат: вивантаження кешу провалилось — {ex.Message}\n");
}


Console.WriteLine("=== Сценарій 3: Вибіркова обробка через shouldRetry ===");
Console.WriteLine("Кидаємо ArgumentException — shouldRetry має заборонити повтор.\n");

try
{
    RetryHelper.ExecuteWithRetry<bool>(
        () => throw new ArgumentException("Некоректний аргумент — не підлягає повтору."),
        retryCount: 4,
        initialDelay: TimeSpan.FromMilliseconds(100),
        shouldRetry: shouldRetry);
}
catch (Exception ex)
{
    Console.WriteLine($"Результат: операція припинена без повторів — {ex.GetType().Name}: {ex.Message}");
}
