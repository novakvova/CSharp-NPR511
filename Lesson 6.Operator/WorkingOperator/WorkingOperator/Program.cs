// See https://aka.ms/new-console-template for more information

using System.Text;
using WorkingOperator;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("--Перегрузка операторів--");

List<Device> devices = new List<Device>();
Device s25 = new Phone(
    manufacturer: "Samsung",
    model: "Galaxy S25",
    price: 799m,
    processor: "Snapdragon 8 Elite for Galaxy",
    ramGb: 12,
    storageGb: 128,
    simCount: 2,
    cameraMegapixels: 50);

Device motorolla = new Phone(
    manufacturer: "Motorolla",
    model: "Moto Signature 16/512 MartiniOlive",
    price: 1000m,
    processor: "Qualcomm Snapdragon 8 Gen 5",
    ramGb: 16,
    storageGb: 512,
    simCount: 2,
    cameraMegapixels: 50);

Device dell = new Laptop(
    manufacturer: "Dell",
    model: "Pro 16 Plus",
    price: 2200m,
    processor: "Intel Core Ultra 7 265U",
    ramGb: 32,
    storageGb: 1024,
    screenSizeInches: 16
    );

Device asus = new Laptop(
    manufacturer: "ASUS",
    model: "Vivobook S16",
    price: 2000m,
    processor: "Intel Core Ultra 9 386H",
    ramGb: 32,
    storageGb: 1024,
    screenSizeInches: 16
    );


devices.Add(s25);
devices.Add(motorolla);
devices.Add(dell);
devices.Add(asus);

Console.WriteLine("Список ваших улюблених пристроїв: ");
foreach (Device dev in devices)
{
    if(dev is Phone) //Якщо це телефон
    {
        Console.WriteLine("++Маємо телефон++");
        //Phone phone = (Phone)dev;
        Phone? phone = dev as Phone; //? phone - може бути null
        Console.WriteLine(phone);

    }
    if(dev is Laptop)
    {
        Console.WriteLine("--Маємо ноутбук--");
        Laptop laptop = (Laptop)dev;
        Console.WriteLine(laptop);
    }
    //Console.WriteLine(dev);
}
//Console.WriteLine(asus);




