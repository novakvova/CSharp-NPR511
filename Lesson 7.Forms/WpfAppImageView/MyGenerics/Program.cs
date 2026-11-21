using MyGenerics.Collections;
using MyGenerics.Generics;
using MyGenerics.Iterators;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Section("1. GENERICS");

Section("1.1 Boxing / unboxing та порівняння з неузагальненими колекціями");
BoxingDemo.Run();

Section("1.2 Узагальнені класи та вкладені типи");
GenericClassesDemo.Run();

Section("1.3 Обмеження (constraints)");
ConstraintsDemo.Run();

Section("1.4 Узагальнені методи");
GenericMethodsDemo.Run();

Section("1.5 Узагальнені інтерфейси");
GenericInterfacesDemo.Run();

Section("2. ITERATORS");
IteratorDemo.Run();

Section("3. COLLECTIONS");
CollectionsDemo.Run();

Section("3.1 Інтерфейси колекцій");
CollectionInterfacesDemo.Run();

static void Section(string title)
{
    Console.WriteLine();
    Console.WriteLine(new string('=', 60));
    Console.WriteLine(title);
    Console.WriteLine(new string('=', 60));
}
