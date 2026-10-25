// See https://aka.ms/new-console-template for more information

using System.Text;
using WorkingStruct;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Привіт усім. Структутри :)");

Person person = new Person();
person.name = "Мельник Матвій";
person.age = 16;

Console.WriteLine("ПІБ: " + person.name);
Console.WriteLine("Вік: " + person.age);
