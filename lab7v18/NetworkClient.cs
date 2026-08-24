using System.Net.Http;

namespace lab7v18;

// Клас, що імітує мережеві запити.
// UploadCache кидає HttpRequestException перші 2 рази, потім успіх.
public class NetworkClient
{
    private int _uploadAttempts = 0;

    // Метод може викидати HttpRequestException (варіант 18: перші 2 спроби невдалі)
    public bool UploadCache(string url, string cacheData)
    {
        _uploadAttempts++;
        if (_uploadAttempts <= 2)
            throw new HttpRequestException(
                $"Не вдалося вивантажити кеш на '{url}' (спроба {_uploadAttempts}): сервер недоступний (503).");

        Console.WriteLine($"  [NetworkClient] Кеш вивантажено на '{url}' ({cacheData.Length} байт).");
        return true;
    }
}
