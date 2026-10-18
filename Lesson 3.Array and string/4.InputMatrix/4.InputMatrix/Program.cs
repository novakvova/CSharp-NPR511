// See https://aka.ms/new-console-template for more information

using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("Вводимо рядок, як двохмірний масив");
int[,] array = null; //двохмірний масив
int index = 0; //поточний індекс у масиві рядка
do
{
    string str = string.Empty; //Пустий рядок
                               //Можемо вводити рядок через ' ' або '\t'
    str = Console.ReadLine();
    //якщо потрібно Split - робити по декількох параметрах,
    //тоді передаємо масив
    //Тут new char [] - це анонімний масив
    string[] strItems = str.Split(new char[] { ' ', '\t' });
    int n = strItems.Length;
    //Console.WriteLine($"Вказано {strItems.Length}");
    if (index == 0)
    {
        array = new int[n, n]; //У мене буде взичайна матриця 
    }

    for (int i = 0; i < n; i++)
    {
        array[index, i] = int.Parse(strItems[i]);
    }

    index++; //перехід на наступний рядок
    if (index == n)
        break; //якщо підійшли до останього рядка
} while (true);


Console.WriteLine("Ви вказали наступний масив:");

int row = array.GetLength(0); //скільки рядків
int col = array.GetLength(1); //скільки стовпчиків
for (int i = 0; i<row;i++)
{
    for(int j = 0; j < col; j++)
        Console.Write($"{array[i,j]}\t");
    Console.WriteLine();
}
