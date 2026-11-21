using System.Collections;

namespace MyGenerics.Collections;

// Узагальнені колекції System.Collections.Generic
public static class CollectionsDemo
{
    public static void Run()
    {
        // List<T> — динамічний масив
        var list = new List<string> { "яблуко", "груша" };
        list.Add("слива");
        list.Insert(1, "банан");
        list.Remove("груша");
        Console.WriteLine($"List: {string.Join(", ", list)}; Count = {list.Count}; IndexOf(слива) = {list.IndexOf("слива")}");

        // Dictionary<TKey, TValue> — пари ключ-значення з швидким пошуком
        var ages = new Dictionary<string, int> { ["Оля"] = 25, ["Петро"] = 31 };
        ages["Іра"] = 19;
        if (ages.TryGetValue("Оля", out int age))
            Console.WriteLine($"Dictionary: Оля = {age}");
        foreach (var (name, value) in ages)
            Console.WriteLine($"  {name}: {value}");

        // Stack<T> — LIFO (останній прийшов — перший вийшов)
        var stack = new Stack<int>();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        Console.WriteLine($"Stack: Peek = {stack.Peek()}, Pop = {stack.Pop()}, Count = {stack.Count}");

        // Queue<T> — FIFO (перший прийшов — перший вийшов)
        var queue = new Queue<string>();
        queue.Enqueue("перший");
        queue.Enqueue("другий");
        Console.WriteLine($"Queue: Dequeue = {queue.Dequeue()}, залишилось = {queue.Count}");

        // SortedList<TKey, TValue> — завжди відсортований за ключем
        var sorted = new SortedList<int, string> { [30] = "тридцять", [10] = "десять", [20] = "двадцять" };
        Console.WriteLine($"SortedList ключі: {string.Join(", ", sorted.Keys)}");

        // HashSet<T> — лише унікальні значення
        var unique = new HashSet<int> { 1, 2, 2, 3, 3, 3 };
        Console.WriteLine($"HashSet: Count = {unique.Count}");

        // LinkedList<T> — вставка на початку і в кінці за O(1)
        var linked = new LinkedList<string>();
        linked.AddLast("b");
        linked.AddFirst("a");
        linked.AddLast("c");
        Console.WriteLine($"LinkedList: {string.Join(", ", linked)}");

        CompareWithNonGeneric();
    }

    // Порівняння з неузагальненою ArrayList
    private static void CompareWithNonGeneric()
    {
        var legacy = new ArrayList();
        legacy.Add(1);
        legacy.Add("рядок");   // компілятор не заважає змішувати типи
        Console.WriteLine($"ArrayList: елемент [1] = {legacy[1]} (тип {legacy[1]?.GetType().Name})");
        // int sum = (int)legacy[0] + (int)legacy[1];   // InvalidCastException під час виконання

        var typed = new List<int> { 1, 2 };
        // typed.Add("рядок");   // помилка компіляції: List<int> приймає лише int
        Console.WriteLine($"List<int>: Count = {typed.Count}; тип помилки ловиться на етапі компіляції");
    }
}
