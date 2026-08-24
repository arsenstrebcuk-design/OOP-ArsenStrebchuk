using System.Threading;

namespace lab7v18;

// Узагальнений допоміжний клас для патерну Retry.
public static class RetryHelper
{
    // operation    — делегат Func<T>, операція, яку треба виконати
    // retryCount   — максимальна кількість спроб
    // initialDelay — початкова затримка (для експоненційної затримки)
    // shouldRetry  — опціональний Func<Exception, bool>: чи повторювати для цього винятку
    public static T ExecuteWithRetry<T>(
        Func<T> operation,
        int retryCount = 3,
        TimeSpan initialDelay = default,
        Func<Exception, bool>? shouldRetry = null)
    {
        if (initialDelay == default)
            initialDelay = TimeSpan.FromMilliseconds(200);

        Exception? lastException = null;

        for (int attempt = 0; attempt < retryCount; attempt++)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                lastException = ex;

                // Вибіркова обробка: якщо shouldRetry каже "ні" — не повторюємо
                if (shouldRetry != null && !shouldRetry(ex))
                {
                    Console.WriteLine(
                        $"  [Retry] Спроба {attempt + 1}: {ex.GetType().Name} не підлягає повтору — кидаємо далі.");
                    throw;
                }

                // Остання спроба — далі повторювати нема сенсу
                if (attempt == retryCount - 1)
                {
                    Console.WriteLine(
                        $"  [Retry] Спроба {attempt + 1}/{retryCount} невдала " +
                        $"({ex.GetType().Name}). Спроби вичерпано.");
                    break;
                }

                // Експоненційна затримка: initialDelay * 2^attempt
                TimeSpan delay = TimeSpan.FromMilliseconds(
                    initialDelay.TotalMilliseconds * Math.Pow(2, attempt));

                Console.WriteLine(
                    $"  [Retry] Спроба {attempt + 1}/{retryCount} невдала " +
                    $"({ex.GetType().Name}: {ex.Message}). Чекаємо {delay.TotalMilliseconds:F0} мс...");

                Thread.Sleep(delay);
            }
        }

        throw lastException!;
    }
}
