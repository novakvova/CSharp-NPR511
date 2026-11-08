namespace WorkingOperator;

public class Phone : Device
{
    private int _simCount;
    private int _cameraMegapixels;

    public Phone() : this("Невідомо", "Невідомо", 0, "Невідомо", 1, 1, 1, 12)
    {
    }

    public Phone(string manufacturer, string model, decimal price, string processor, int ramGb, int storageGb, int simCount, int cameraMegapixels)
        : base(manufacturer, model, price, processor, ramGb, storageGb)
    {
        SimCount = simCount;
        CameraMegapixels = cameraMegapixels;
    }

    public int SimCount
    {
        get => _simCount;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Кількість SIM-карток має бути більшою за нуль.");
            _simCount = value;
        }
    }

    public int CameraMegapixels
    {
        get => _cameraMegapixels;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Кількість мегапікселів камери має бути більшою за нуль.");
            _cameraMegapixels = value;
        }
    }

    public override string ToString() =>
        $"{base.ToString()}, SIM-карток: {SimCount}, камера: {CameraMegapixels} Мп";
}
