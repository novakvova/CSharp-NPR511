using System.Text.RegularExpressions;

namespace MyExample;

public class Person
{
    private string _id;
    private string _name;
    private string _phone;
    //ctor
    public Person()
    {
        _id=Guid.NewGuid().ToString(); //Унікальний ідентифікатор для елемента
        _name = _phone = String.Empty; //пустрий рядок
    }

    public Person(string name, string phone)
        : this() //визиваю конструктор по замовчуванню
    {
        //_name = name;
        //_phone = phone;
        Name = name; //автоматично буде перевірка
        Phone = phone; //автоматично буде перевірка
    }
    //перегрузка базового ToString()
    public override string ToString()
    {
        string str = $"Id: {_id}\n" +
            $"Name: {_name}\n" +
            $"Phone: {_phone}";
        return str;
    }

    public string Id
    {
        get { return _id; } //Id не можемо змінювати
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if(value.Length < 2)
                Console.WriteLine("Ім'я має бути мін 2 символи :(");
            else
            {
                _name = value;
            }
        }
    }
    public string Phone
    {
        get { return _phone; }
        set
        {
            //У програмування для складних перевірок придумали Regex
            //Можна перевіряти рядок, чи є там вірно вказано синтаксис
            //Може починати із +380968789321 - 13 символів
            //380968789321 - тобто це ? - + може бути не бути - 12 символів
            //80968789321 - тобто це ? - + може бути не бути - 11 символів
            //0968789321 - тобто це ? - + може бути не бути - 10 символів
            //Усі інші способи не піходять
            string regex = @"^\+?[0-9]{12}$"; //телефону від 10 до цифр 13 символів
            if(!Regex.IsMatch(value, regex))
                Console.WriteLine("Телефон вказано не вірно (+38XXXXXXXXXX) :(");
            else
            {
                _phone = value;
            }
        }
    }
}
