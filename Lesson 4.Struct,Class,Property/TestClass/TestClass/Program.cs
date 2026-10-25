// See https://aka.ms/new-console-template for more information


using System.Text;
using TestClass;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("--Класи, конструктор, методи класу--");

Laptop my = new Laptop();

//Виводжу інформацію про Laptop
Console.WriteLine(my);
//Console.WriteLine(my.ToString());

my.SetBrand("HP");
//my.SetModel("");
my.Model = "EliteBook 14 G10"; //тут буде Set

string model = my.Model; //тут працює GET

my.AddMemory(96); //Має видати помилку

my.SetCPU("Intel Core i7-1335u");

Console.WriteLine("Виробник: " + my.GetBrand());
Console.WriteLine("Модель: " + my.Model);
Console.WriteLine("CPU: " + my.GetCPU());
