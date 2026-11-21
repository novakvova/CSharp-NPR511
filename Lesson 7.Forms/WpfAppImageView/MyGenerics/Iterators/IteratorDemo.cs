using System.Collections;

namespace MyGenerics.Iterators;

// Ітератор — метод з yield: компілятор сам створює клас, що реалізує IEnumerator<T>
public static class IteratorDemo
{
    // yield return віддає по одному елементу
    public static IEnumerable<int> Range(int start, int count)
    {
        for (int i = 0; i < count; i++)
            yield return start + i;
    }

    // yield break завершує ітератор достроково
    public static IEnumerable<int> TakeWhilePositive(IEnumerable<int> source)
    {
        foreach (int x in source)
        {
            if (x <= 0)
                yield break;
            yield return x;
        }
    }

    // Нескінченна послідовність: значення обчислюються лише тоді, коли їх запитують
    public static IEnumerable<long> Fibonacci()
    {
        long a = 0, b = 1;
        while (true)
        {
            yield return a;
            (a, b) = (b, a + b);
        }
    }

    // Код ітератора виконується лише під час перебору (ліниве виконання)
    public static IEnumerable<int> Trace(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            Console.WriteLine($"  [ітератор] обчислюю {i}");
            yield return i * i;
        }
    }

    public static void Run()
    {
        Console.WriteLine("Range(10, 5): " + string.Join(", ", Range(10, 5)));
        Console.WriteLine("TakeWhilePositive(3, 5, -1, 7): " + string.Join(", ", TakeWhilePositive(new[] { 3, 5, -1, 7 })));
        Console.WriteLine("Fibonacci (перші 10): " + string.Join(", ", Fibonacci().Take(10)));

        Console.WriteLine("Створюємо ітератор Trace(3) — код ще не виконався");
        IEnumerable<int> squares = Trace(3);
        Console.WriteLine("Починаємо перебір:");
        foreach (int sq in squares)
            Console.WriteLine($"  значення {sq}");

        var playlist = new Playlist();
        playlist.Add("Track 1");
        playlist.Add("Track 2");
        playlist.Add("Track 3");
        Console.WriteLine("Playlist (зворотний порядок): " + string.Join(", ", playlist));
    }
}

// Власна колекція з ітератором: реалізуємо IEnumerable<T>
public class Playlist : IEnumerable<string>
{
    private readonly List<string> _tracks = new();

    public void Add(string track) => _tracks.Add(track);

    public IEnumerator<string> GetEnumerator()
    {
        for (int i = _tracks.Count - 1; i >= 0; i--)
            yield return _tracks[i];
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
