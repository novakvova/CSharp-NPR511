namespace WorkingOperator;

public abstract class Device
{
    #region Тут приватний модуль класу
    private string _manufacturer = string.Empty;
    private string _model = string.Empty;
    private decimal _price;
    private string _processor = string.Empty;
    private int _ramGb;
    private int _storageGb;
    #endregion

    protected Device() : this("Невідомо", "Невідомо", 0, "Невідомо", 1, 1)
    {
    }

    protected Device(string manufacturer, string model, decimal price, string processor, int ramGb, int storageGb)
    {
        Manufacturer = manufacturer;
        Model = model;
        Price = price;
        Processor = processor;
        RamGb = ramGb;
        StorageGb = storageGb;
    }

    #region Тут властивості класу
    public string Manufacturer
    {
        get => _manufacturer;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Виробник не може бути порожнім.", nameof(value));
            _manufacturer = value;
        }
    }

    public string Model
    {
        get => _model;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Модель не може бути порожньою.", nameof(value));
            _model = value;
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Ціна не може бути від'ємною.");
            _price = value;
        }
    }

    public string Processor
    {
        get => _processor;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Процесор не може бути порожнім.", nameof(value));
            _processor = value;
        }
    }

    public int RamGb
    {
        get => _ramGb;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Обсяг оперативної пам'яті має бути більшим за нуль.");
            _ramGb = value;
        }
    }

    public int StorageGb
    {
        get => _storageGb;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Обсяг постійної пам'яті має бути більшим за нуль.");
            _storageGb = value;
        }
    }
    #endregion
    
    public override string ToString() =>
        $"{Manufacturer} {Model}, процесор: {Processor}, ОЗП: {RamGb} ГБ, пам'ять: {StorageGb} ГБ, ціна: {Price:F2}";
}
