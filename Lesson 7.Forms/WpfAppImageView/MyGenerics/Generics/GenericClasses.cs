namespace MyGenerics.Generics;

// Узагальнений клас: T — параметр типу, який вказують під час створення об'єкта
public class Box<T>
{
    public Box(T value) => Value = value;

    public T Value { get; set; }

    public override string ToString() => $"Box<{typeof(T).Name}>: {Value}";
}

// Узагальнений клас із двома параметрами типу
public class Pair<TKey, TValue>
{
    public Pair(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }

    public TKey Key { get; }
    public TValue Value { get; }

    public override string ToString() => $"({Key}, {Value})";
}

// Стек на зв'язному списку з вкладеними типами
public class LinkedStack<T>
{
    // Вкладений клас використовує T зовнішнього класу, тому теж є узагальненим
    private class Node
    {
        public Node(T data) => Data = data;

        public T Data { get; }
        public Node? Next { get; set; }
    }

    // Вкладений перелік не залежить від T
    public enum State { Empty, NotEmpty }

    private Node? _top;

    public int Count { get; private set; }

    public State CurrentState => _top is null ? State.Empty : State.NotEmpty;

    public void Push(T item)
    {
        _top = new Node(item) { Next = _top };
        Count++;
    }

    public T Pop()
    {
        if (_top is null)
            throw new InvalidOperationException("Стек порожній");

        T data = _top.Data;
        _top = _top.Next;
        Count--;
        return data;
    }
}

public static class GenericClassesDemo
{
    public static void Run()
    {
        var intBox = new Box<int>(7);
        var textBox = new Box<string>("привіт");
        Console.WriteLine(intBox);
        Console.WriteLine(textBox);

        var pair = new Pair<string, int>("Київ", 2800000);
        Console.WriteLine($"Пара: {pair}");

        var stack = new LinkedStack<string>();
        stack.Push("перший");
        stack.Push("другий");
        Console.WriteLine($"Count = {stack.Count}, стан = {stack.CurrentState}");
        Console.WriteLine($"Pop: {stack.Pop()}");
        Console.WriteLine($"Pop: {stack.Pop()}");
        Console.WriteLine($"Стан після видалення = {stack.CurrentState}");
    }
}
