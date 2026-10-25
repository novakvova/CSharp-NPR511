// See https://aka.ms/new-console-template for more information
//С# - повністю ООП - тобто усе тут через класи
//Навіть код, який ми пишемо - це клас

using System.Text;

//Якщо пишемо на С#, то є функція Main - як у С++
//У С# - це метод класу, а методи пишуться з великої букви
//Для простоти програмування, цю функцію вони у 8, 9, 10 dotnet
//приховали
namespace MyClass; //Простір імен - де знаходить клас Program

class Program
{
    public static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        Console.WriteLine("-- Працюємо з класами --");
        //Кількість параметрів у рядку
        int n = args.Length;
        //for (int i = 0; i < n; i++)
        //{
        //    Console.WriteLine($"{i + 1}.{args[i]}");
        //}
        if(n==1)
        {
            string str = args[0];
            if(str.Equals("-v"))
            {
                Console.WriteLine("Version: 1.023");
            }
        }
        string[] names = { "Дженіфер", "Галина", "Олена" };
        if(n==2)
        {
            foreach(string arg in args)
            {
                string? isFind = names.FirstOrDefault(x => x.Equals(arg));
                if (isFind != null)
                {
                    Console.WriteLine($"Знайдено: {arg}");
                }
                else
                {
                    Console.WriteLine($"Дана людина відсутня в БД: {arg}");
                }
            }
        }
    }
}

