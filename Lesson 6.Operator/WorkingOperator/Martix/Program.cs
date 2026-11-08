// See https://aka.ms/new-console-template for more information

using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("--Робота з матрицями--");

MyMatrix m = new MyMatrix(2, 3);
m[0, 0] = 1; m[0, 1] = 2; m[0, 2] = 3;
m[1, 0] = 4; m[1, 1] = 5; m[1, 2] = 6;

Console.WriteLine("Матриця:");
Console.WriteLine(m);

Console.WriteLine("Транспонована:");
Console.WriteLine(m.Transpose());


