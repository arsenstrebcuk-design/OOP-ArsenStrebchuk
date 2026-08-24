# Лабораторна робота №7 — Обробка IO/мережевих помилок та патерн Retry

**Варіант 18: Збереження кешу**

## Тема та мета

**Тема:** обробка типових помилок вводу/виводу та мережевих помилок за допомогою `try-catch-finally`, а також реалізація патерну Retry.

**Мета:** навчитися обробляти IO/мережеві винятки і реалізувати патерн Retry з експоненційною затримкою для підвищення відмовостійкості застосунків.

## Опис виконання завдання (варіант 18)

- **`FileProcessor.SaveCache(path, cacheData)`** — імітує `IOException` перші 4 рази, потім успіх.
- **`NetworkClient.UploadCache(url, cacheData)`** — імітує `HttpRequestException` перші 2 рази, потім успіх.
- **`shouldRetry`** — повторювати лише для `IOException` та `HttpRequestException`.

### Файли

- **`FileProcessor.cs`** — робота з файлами, метод `SaveCache`.
- **`NetworkClient.cs`** — мережеві запити, метод `UploadCache`.
- **`RetryHelper.cs`** — узагальнений клас з методом `ExecuteWithRetry<T>` (експоненційна затримка + логування).
- **`Program.cs`** — демонстрація в `Main`: сценарії тимчасових помилок + вибіркова обробка через `shouldRetry`.

### Реалізовано

- `try-catch` для IO та мережевих винятків;
- узагальнений `RetryHelper.ExecuteWithRetry<T>(Func<T>, int, TimeSpan, Func<Exception,bool>)`;
- **експоненційна затримка** `initialDelay * 2^retryAttempt`;
- логування кожної спроби та причини невдачі;
- `shouldRetry` для вибіркової обробки винятків.

## Приклад запуску

<img width="1126" height="297" alt="image" src="https://github.com/user-attachments/assets/9d4a3fd9-7d12-4bff-a677-e6b19d120850" />

