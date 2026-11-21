using System.Collections;
using System.Diagnostics;

namespace MyGenerics.Generics;

// Boxing — упаковка значущого типу (int) в object: значення копіюється в купу.
// Unboxing — повернення значення з object назад у значущий тип.
public static class BoxingDemo
{
    public static void Run()
    {
        int number = 42;

        object boxed = number;      // boxing: int -> object
        number = 100;               // змінюємо оригінал — упаковане значення не змінюється
        Console.WriteLine($"boxed = {boxed}, number = {number}");

        int unboxed = (int)boxed;   // unboxing: object -> int
        Console.WriteLine($"unboxed = {unboxed}");

        try
        {
            _ = (string)boxed;      // розпаковуємо int як string
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("InvalidCastException: неможливо розпакувати int як string");
        }

        // Порівняння продуктивності: неузагальнена колекція проти узагальненої
        const int count = 1_000_000;

        var legacy = new ArrayList();
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < count; i++)
            legacy.Add(i);                                       // boxing при кожному Add
        long sumLegacy = 0;
        foreach (object item in legacy)
            sumLegacy += (int)item;                              // unboxing при кожній ітерації
        sw.Stop();
        Console.WriteLine($"ArrayList: сума = {sumLegacy}, час = {sw.ElapsedMilliseconds} мс");

        var typed = new List<int>(count);
        sw.Restart();
        for (int i = 0; i < count; i++)
            typed.Add(i);                                        // без упаковки
        long sumTyped = 0;
        foreach (int item in typed)
            sumTyped += item;
        sw.Stop();
        Console.WriteLine($"List<int>: сума = {sumTyped}, час = {sw.ElapsedMilliseconds} мс");
    }
}
