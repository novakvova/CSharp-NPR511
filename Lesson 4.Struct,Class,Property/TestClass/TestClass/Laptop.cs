namespace TestClass;

public class Laptop
{
    //Інкапсуляція - приховання та захист даних
    //private - проховані значення у класі
    private string _brand;
    private string _model;
    private string _cpu;
    private int _ram;
    private int _storage;

    //будуємо конструктор ctor
    public Laptop()
    {
        _brand = "Dell";
        _model = "Precition 5560";
        _cpu = "i7-11850H";
        _ram = 48;
        _storage = 2000;
    }

    //На основі базоваого Object перевизначити ToString()
    public override string ToString()
    {
        string str = "";
        str += $"Виробник: {_brand}\n";
        str += $"Модель: {_model}\n";
        str += $"Процесор: {_cpu}\n";
        str += $"Оперативка: {_ram}Gb\n";
        str += $"Диск: {_storage}";
        return str;
    }
    //Get і Set
    public void SetBrand(string brand)
    {
        _brand = brand;
    }
    public string GetBrand()
    {
        return _brand;
    }

    //Можна роботи властивості - Властивість - це метод,
    //який пишеть без дужок у кінці, може робити
    //get, set, лише get або лише set
    //Як передати в метод значення, якщо немає дужок
    //є спец. слова - value - який зберігає значеня для set
    public string Model
    {
        get { return _model; }
        set { _model = value; }
    }

    //Метод збільшує Оперативку
    public void AddMemory(int size)
    {
        int update = _ram + size;
        if (update > _ram)
        {
            if(update > 128)
            {
                Console.WriteLine("Не можна ставити більше 128 Гб");
            }
            _ram=update;
        }
        else
        {
            Console.WriteLine("Не можна зменшувати. Буде тупити ПК.");
        }
    }

    //public string GetCPU() { return _cpu; }
    public string GetCPU() => _cpu; //Це так само, як зверху у коментарі
    //public void SetCPU(string cpu) { _cpu = cpu; }
    public void SetCPU(string cpu) => _cpu = cpu;
}
