// See https://aka.ms/new-console-template for more information


using MyExample;
using System.Text;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

Console.WriteLine("-- Наслідування --");

//--------------Step 1--------------------------
//Person ivan = new Person();
//Console.WriteLine("ivan = "+ivan);
//Person sveta = new Person("Світлана Михайлівна", "+38 097 34 56 234");
//Console.WriteLine("Світалана = "+sveta);

//---------------Step 2--------------------------
//Student petro = new Student();
////Student dima = new Student();
//Student vova = new Student("Новак Вова", "38 097 76 65 453");

//Student olena = new Student(name: "Мельник Олена", phone: "38 098 76 34 712", 
//    group: "СПР-23", speciality: "Програмна-інженерія", course: 1, 
//    faculty: "Кібернетики");

//Console.WriteLine("Петро = " + petro);
//Console.WriteLine("Вова = " + vova);
//Console.WriteLine("Олена = " + olena);

//----------------Step 3-------------------------
//Console.WriteLine("Вкажіть дані про студента:");

//Console.Write("Ім'я: ");
//string name = Console.ReadLine();
//Console.Write("Телефон: ");
//string phone = Console.ReadLine();
//Console.Write("Факультет: ");
//string faculty = Console.ReadLine();
//Console.Write("Спеціальність: ");
//string speciality = Console.ReadLine();
//Console.Write("Курс: ");
//int course = int.Parse(Console.ReadLine());
////string course = Console.ReadLine();
//Console.Write("Група: ");
//string group = Console.ReadLine();

//Console.WriteLine("Ваш студент:");
//Student temp = new Student(name, phone, group, speciality, course,faculty);
//Console.WriteLine(temp);

//-----------------------Step 4------------------------
Console.WriteLine("Вкажіть дані про студента:");

Student step = new Student();

Console.Write("Ім'я: ");
step.Name = Console.ReadLine();
Console.Write("Телефон: ");
step.Phone = Console.ReadLine();
Console.Write("Факультет: ");
step.Faculty = Console.ReadLine();
Console.Write("Спеціальність: ");
step.Speciality = Console.ReadLine();
Console.Write("Курс: ");
step.Course = int.Parse(Console.ReadLine());
Console.Write("Група: ");
step.Group = Console.ReadLine();

Console.WriteLine("Ваш студент:");
Console.WriteLine(step);

