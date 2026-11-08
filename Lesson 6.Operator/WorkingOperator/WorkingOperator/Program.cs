// See https://aka.ms/new-console-template for more information

using System.Text;
using WorkingOperator;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("--Перегрузка операторів--");

Device s25 = new Phone(
    manufacturer: "Samsung",
    model: "Galaxy S25",
    price: 799m,
    processor: "Snapdragon 8 Elite for Galaxy",
    ramGb: 12,
    storageGb: 128,
    simCount: 2,
    cameraMegapixels: 50);

Console.WriteLine(s25);
