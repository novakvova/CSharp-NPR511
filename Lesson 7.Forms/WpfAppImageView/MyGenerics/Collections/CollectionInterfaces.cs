using System.Collections;

namespace MyGenerics.Collections;

// Інтерфейси колекцій: методи приймають інтерфейс, а не конкретний клас
public static class CollectionInterfacesDemo
{
    // IList<T> — індексований доступ і вставка
    public static void PrintList<T>(IList<T> list)
    {
        for (int i = 0; i < list.Count; i++)
            Console.WriteLine($"  [{i}] = {list[i]}");
    }

    // ICollection<T> — лише Count, Add, Contains, Remove
    public static void Fill<T>(ICollection<T> target, IEnumerable<T> source)
    {
        foreach (T item in source)
            target.Add(item);
    }

    // IDictionary<TKey, TValue> — будь-який словник
    public static void PrintDictionary<TKey, TValue>(IDictionary<TKey, TValue> dict)
        where TKey : notnull
    {
        foreach (KeyValuePair<TKey, TValue> pair in dict)
            Console.WriteLine($"  {pair.Key} -> {pair.Value}");
    }

    public static void Run()
    {
        IList<string> names = new List<string> { "Яна", "Олег" };
        names.Insert(1, "Марія");
        Console.WriteLine("IList<T>:");
        PrintList(names);

        ICollection<int> numbers = new HashSet<int>();
        Fill(numbers, new[] { 1, 2, 3 });
        Console.WriteLine($"ICollection<T>: Count = {numbers.Count}, містить 2: {numbers.Contains(2)}");

        IDictionary<string, int> stock = new Dictionary<string, int> { ["яблука"] = 5, ["груші"] = 2 };
        Console.WriteLine("IDictionary<TKey, TValue>:");
        PrintDictionary(stock);

        // IComparer<T> — власний порядок сортування
        var words = new List<string> { "дерево", "кіт", "будинок" };
        words.Sort(new ByLengthComparer());
        Console.WriteLine($"IComparer<T> (за довжиною): {string.Join(", ", words)}");

        // IEnumerable<T> і IEnumerator<T> — що робить foreach
        Console.Write("IEnumerable<T> (foreach): ");
        foreach (int n in new Countdown(3))
            Console.Write(n + " ");
        Console.WriteLine();

        Console.Write("IEnumerator<T> (вручну): ");
        using IEnumerator<int> e = new Countdown(2).GetEnumerator();
        while (e.MoveNext())
            Console.Write(e.Current + " ");
        Console.WriteLine();
    }
}

// Порівнює рядки за довжиною
public class ByLengthComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        int lengthX = x?.Length ?? 0;
        int lengthY = y?.Length ?? 0;
        return lengthX.CompareTo(lengthY);
    }
}

// Ручна реалізація IEnumerator<T> — приблизно те, що компілятор генерує для yield
public class CountdownEnumerator : IEnumerator<int>
{
    private readonly int _start;
    private int _index = -1;

    public CountdownEnumerator(int start) => _start = start;

    public int Current
    {
        get
        {
            if (_index < 0 || _index > _start)
                throw new InvalidOperationException("Немає поточного елемента");
            return _start - _index;
        }
    }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (_index < _start)
        {
            _index++;
            return true;
        }
        return false;
    }

    public void Reset() => _index = -1;

    public void Dispose()
    {
    }
}

// Колекція, яка повертає CountdownEnumerator: від start до 0
public class Countdown : IEnumerable<int>
{
    private readonly int _start;

    public Countdown(int start) => _start = start;

    public IEnumerator<int> GetEnumerator() => new CountdownEnumerator(_start);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
