using System.Globalization;
using System.Numerics;

namespace MyGenerics.Generics;

public abstract class Entity
{
    public int Id { get; set; }
}

public class Customer : Entity
{
    public string Name { get; set; } = "";
}

// where TEntity : Entity, new() — базовий клас дає Id, new() дозволяє створити об'єкт
public class Repository<TEntity> where TEntity : Entity, new()
{
    private readonly List<TEntity> _items = new();
    private int _nextId = 1;

    public TEntity Create()
    {
        var entity = new TEntity { Id = _nextId++ };
        _items.Add(entity);
        return entity;
    }

    public TEntity? FindById(int id) => _items.FirstOrDefault(e => e.Id == id);
}

public static class ConstraintsDemo
{
    // where T : IComparable<T> — значення можна порівнювати
    public static T Max<T>(T a, T b) where T : IComparable<T>
        => a.CompareTo(b) >= 0 ? a : b;

    // where T : INumber<T> — арифметика для будь-якого числового типу (.NET 7+)
    public static T Sum<T>(IEnumerable<T> items) where T : INumber<T>
    {
        T total = T.Zero;
        foreach (T item in items)
            total += item;
        return total;
    }

    // where T : struct, IParsable<T> — значущий тип, який уміє розбирати рядок
    public static T? ParseOrNull<T>(string text) where T : struct, IParsable<T>
    {
        if (T.TryParse(text, CultureInfo.InvariantCulture, out T result))
            return result;
        return null;
    }

    // where T : new() — можна створити об'єкт без параметрів
    public static T CreateDefault<T>() where T : new() => new T();

    public static void Run()
    {
        Console.WriteLine($"Max(3, 9) = {Max(3, 9)}");
        Console.WriteLine($"Max(\"apple\", \"pear\") = {Max("apple", "pear")}");

        Console.WriteLine($"Sum(int) = {Sum(new[] { 1, 2, 3 })}");
        Console.WriteLine($"Sum(double) = {Sum(new[] { 1.5, 2.25 })}");

        Console.WriteLine($"ParseOrNull<int>(\"123\") ?? -1 = {ParseOrNull<int>("123") ?? -1}");
        Console.WriteLine($"ParseOrNull<int>(\"abc\") ?? -1 = {ParseOrNull<int>("abc") ?? -1}");

        Console.WriteLine($"CreateDefault<List<int>>().Count = {CreateDefault<List<int>>().Count}");

        var repo = new Repository<Customer>();
        Customer ivan = repo.Create();
        ivan.Name = "Іван";
        Customer olena = repo.Create();
        olena.Name = "Олена";

        Customer? found = repo.FindById(2);
        Console.WriteLine($"FindById(2): {found?.Name ?? "не знайдено"}");

        // Max(new object(), new object());  // помилка компіляції: object не реалізує IComparable<object>
    }
}
