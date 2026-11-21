namespace MyGenerics.Generics;

public static class GenericMethodsDemo
{
    // Тип T визначається з аргументів
    public static void Swap<T>(ref T a, ref T b)
    {
        (a, b) = (b, a);
    }

    // Два параметри типу: вхідний і вихідний
    public static TOut Transform<TIn, TOut>(TIn input, Func<TIn, TOut> converter)
        => converter(input);

    public static T[] Repeat<T>(T item, int count)
    {
        var result = new T[count];
        for (int i = 0; i < count; i++)
            result[i] = item;
        return result;
    }

    public static void Run()
    {
        int x = 1, y = 2;
        Swap(ref x, ref y);                 // T = int, виведено автоматично
        Console.WriteLine($"x = {x}, y = {y}");

        string s1 = "A", s2 = "B";
        Swap<string>(ref s1, ref s2);       // T вказано явно
        Console.WriteLine($"s1 = {s1}, s2 = {s2}");

        int length = Transform("тест", s => s.Length);   // TIn = string, TOut = int
        Console.WriteLine($"Довжина рядка = {length}");

        string[] stars = Repeat("*", 5);
        Console.WriteLine(string.Join(" ", stars));
    }
}
