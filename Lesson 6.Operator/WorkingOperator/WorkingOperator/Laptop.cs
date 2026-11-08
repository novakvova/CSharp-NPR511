namespace WorkingOperator;

public class Laptop : Device
{
    private double _screenSizeInches;

    public Laptop() : this("Невідомо", "Невідомо", 0, "Невідомо", 1, 1, 13.3)
    {
    }

    public Laptop(string manufacturer, string model, decimal price, string processor, int ramGb, int storageGb, double screenSizeInches)
        : base(manufacturer, model, price, processor, ramGb, storageGb)
    {
        ScreenSizeInches = screenSizeInches;
    }

    public double ScreenSizeInches
    {
        get => _screenSizeInches;
        set
        {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Діагональ екрана має бути більшою за нуль.");
            _screenSizeInches = value;
        }
    }

    public override string ToString() =>
        $"{base.ToString()}, діагональ: {ScreenSizeInches} дюймів";
}
