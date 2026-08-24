namespace lab7v18;

// Клас, що імітує роботу з файлами.
// SaveCache кидає IOException перші 4 рази, потім завершується успішно.
public class FileProcessor
{
    private int _saveAttempts = 0;

    // Метод може викидати IOException (варіант 18: перші 4 спроби невдалі)
    public void SaveCache(string path, string cacheData)
    {
        _saveAttempts++;
        if (_saveAttempts <= 4)
            throw new IOException(
                $"Не вдалося записати кеш у '{path}' (спроба {_saveAttempts}): файл зайнято іншим процесом.");

        Console.WriteLine($"  [FileProcessor] Кеш збережено у '{path}' ({cacheData.Length} байт).");
    }
}
