namespace lab4v18;

// Інтерфейс-контракт: усі валідатори мають мати назву та метод перевірки
public interface IValidator
{
    string Name { get; }
    bool IsValid(string value);
}
