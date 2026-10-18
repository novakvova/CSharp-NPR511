// See https://aka.ms/new-console-template for more information

using System.Text;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

Console.WriteLine("-- Привіт! Працюємо із Масивами :) --");
//Одномірні масиви
int n = 10;
//створили масив
double[] myArrya = new double[n];
Random r = new Random();
for (int i = 0; i < n; i++)
{
    myArrya[i] = r.NextDouble();
}
Console.WriteLine("Наш масив:");
//масив покажемо через цикл foreach
//У С# придумали, що якщо ми з права знаємо, який тип даних
//тоді можна писати var - це автотичний тип, який буде з права
//тут у нас з права - double, тоді var - стає double
foreach(var item in myArrya) 
{
    Console.Write($"{item}\t");
}