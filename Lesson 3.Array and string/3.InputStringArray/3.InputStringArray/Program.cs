// See https://aka.ms/new-console-template for more information

using System.Text;
Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

Console.WriteLine("Вводимо рядок. Як масив :)");
Console.WriteLine("Вкажіть рядок чисел:");
String str = Console.ReadLine();
Console.WriteLine($"Ваш рядок {str}");
///При роботі із рядками на C# - дуже багато
///допоміжних методів.
///Один символ задається через ' ' - одинарні кавички
///тип даних char
///поділ рядка буде на багато рядків, які ідуть через ' '
string[] items = str.Split(' ');
Console.WriteLine("Результат поділу на пробіли:");
foreach(string s in items)
{
    Console.WriteLine($"++{s}++");
}
//Створюю масив цілих чисел довжиною items.Length
int[] array = new int[items.Length];
for(int i = 0; i < items.Length; i++)
{
    //Ми рядок i - перетворюємо у ціле число
    array[i] = int.Parse(items[i]);
}
int summ = 0;
for(int i = 0;i < array.Length; i++)
{
    summ+= array[i];
}
Console.WriteLine($"Сума усіх елементів масиву: {summ}");
