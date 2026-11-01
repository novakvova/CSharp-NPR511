namespace MyExample;

public class Student : Person
{
    private string _group; //Група
    private string _speciality; //Спеціальність
    private int _course; //Курс 
    private string _faculty; //Факультет
    public Student()
    {
        
    }

    public Student(string name, string phone)
        : base(name, phone) { }

    public Student(string name, 
        string phone, string group, 
        string speciality, 
        int course, string faculty) : base(name, phone) 
    {
        _course = course;
        _group = group;
        _speciality = speciality;
        _faculty = faculty;
    }

    public override string ToString()
    {
        string str = base.ToString(); //Так працює по default
        str += "\n";
        str += $"Курс: {_course}\n";
        str += $"Група: {_group}\n";
        str += $"Факультет: {_faculty}\n";
        str += $"Спеціальність: {_speciality}";
        return str; 
    }

    public int Course
    {
        get { return _course; }
        set
        {
            if (value <= 0 || value > 6) // 1
            {
                Console.WriteLine("Не можу бути курс у межах від 1 до 6");
            }
            else
            {
                _course = value;
            }
        }
    }

    public string Group
    {
        get { return _group; }
        set
        {
            if (value.Length < 2)
                Console.WriteLine("Група має бути мін 2 символи :(");
            else
            {
                _group = value;
            }
        }
    }

    public string Faculty
    {
        get { return _faculty; }
        set
        {
            if (value.Length < 2)
                Console.WriteLine("Факультет має бути мін 2 символи :(");
            else
            {
                _faculty = value;
            }
        }
    }

    public string Speciality
    {
        get { return _speciality; }
        set
        {
            if (value.Length < 2)
                Console.WriteLine("Спеціальність має бути мін 2 символи :(");
            else
            {
                _speciality = value;
            }
        }
    }
}
