namespace MyGenerics.Generics;

// Узагальнений інтерфейс репозиторію
public interface IRepository<T> where T : class
{
    void Add(T item);
    IEnumerable<T> GetAll();
    T? FindFirst(Func<T, bool> predicate);
}

public class InMemoryRepository<T> : IRepository<T> where T : class
{
    private readonly List<T> _items = new();

    public void Add(T item) => _items.Add(item);

    public IEnumerable<T> GetAll() => _items;

    public T? FindFirst(Func<T, bool> predicate) => _items.FirstOrDefault(predicate);
}

// out T — коваріантність: IProducer<Dog> можна використати як IProducer<Animal>
public interface IProducer<out T>
{
    T Produce();
}

// in T — контраваріантність: IConsumer<Animal> можна використати як IConsumer<Dog>
public interface IConsumer<in T>
{
    void Consume(T item);
}

public class Animal
{
    public string Name { get; init; } = "";
}

public class Dog : Animal
{
}

public class DogFactory : IProducer<Dog>
{
    private int _count;

    public Dog Produce() => new Dog { Name = $"Собака #{++_count}" };
}

public class AnimalPrinter : IConsumer<Animal>
{
    public void Consume(Animal item) => Console.WriteLine($"Тварина: {item.Name}");
}

public static class GenericInterfacesDemo
{
    public static void Run()
    {
        IRepository<Dog> repo = new InMemoryRepository<Dog>();
        repo.Add(new Dog { Name = "Рекс" });
        repo.Add(new Dog { Name = "Барсик" });

        Dog? found = repo.FindFirst(d => d.Name.StartsWith("Б"));
        Console.WriteLine($"Знайдено: {found?.Name ?? "немає"}");
        Console.WriteLine($"Усього: {repo.GetAll().Count()}");

        // Коваріантність
        IProducer<Animal> producer = new DogFactory();
        Animal pet = producer.Produce();
        Console.WriteLine($"Вироблено: {pet.Name}");

        // Контраваріантність
        IConsumer<Dog> consumer = new AnimalPrinter();
        consumer.Consume(new Dog { Name = "Мурка" });
    }
}
