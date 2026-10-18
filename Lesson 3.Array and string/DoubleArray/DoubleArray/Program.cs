using System.Text;
Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;

Console.WriteLine("Працюю із двохмірними масивами");

int n=3, m=3; //Робимо масив 3х3
//, - означає, що це двохміний масив
int[,] matrix = new int[n,m]; //створили масив

Random r = new Random();
//Заповнимо масив випадковими числами
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < m; j++)
    {
        matrix[i, j] = r.Next(0,20);
    }
}

Console.WriteLine("Наш масив: ");
for (int i = 0;i < n; i++)
{
    for(int j = 0; j < m;j++)
    {
        Console.Write($"{matrix[i,j]}\t");
    }
    Console.WriteLine();
}
