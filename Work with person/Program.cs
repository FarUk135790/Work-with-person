using System;

class Person
{
    private string name;
    private DateTime birthYear;

    public string Name
    {
        get { return name; }
    }

    public DateTime BirthYear
    {
        get { return birthYear; }
    }

    public Person()
    {
        // Конструктор за замовчуванням
    }

    public Person(string name, DateTime birthYear)
    {
        this.name = name;
        this.birthYear = birthYear;
    }

    public int Age()
    {
        return DateTime.Now.Year - birthYear.Year;
    }

    public void Input()
    {
        Console.Write("Введіть ім'я: ");
        name = Console.ReadLine();
        Console.Write("Введіть рік народження: ");
        int year = int.Parse(Console.ReadLine());
        Console.Write("Введіть місяць народження: ");
        int month = int.Parse(Console.ReadLine());
        Console.Write("Введіть день народження: ");
        int day = int.Parse(Console.ReadLine());

        birthYear = new DateTime(year, month, day);
    }

    public void ChangeName()
    {
        Console.Write("Введіть нове ім'я: ");
        name = Console.ReadLine();
    }

    public override string ToString()
    {
        return $"Ім'я: {name}, Рік народження: {birthYear.Year}";
    }

    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public static bool operator ==(Person person1, Person person2)
    {
        return person1.name == person2.name;
    }

    public static bool operator !=(Person person1, Person person2)
    {
        return !(person1 == person2);
    }
}

class Program
{
    static void Main()
    {
        Person[] people = new Person[6];

        for (int i = 0; i < people.Length; i++)
        {
            people[i] = new Person();
            people[i].Input();
        }

        foreach (var person in people)
        {
            int age = person.Age();
            Console.WriteLine($"Ім'я: {person.Name}, Вік: {age}");

            if (age < 16)
            {
                person.ChangeName("Very Young");
            }
        }

        Console.WriteLine("\nІнформація про всіх осіб:");

        foreach (var person in people)
        {
            person.Output();
        }

        Console.WriteLine("\nІнформація про осіб з однаковими іменами:");

        for (int i = 0; i < people.Length - 1; i++)
        {
            for (int j = i + 1; j < people.Length; j++)
            {
                if (people[i] == people[j])
                {
                    Console.WriteLine("Особи з однаковим іменем:");
                    people[i].Output();
                    people[j].Output();
                }
            }
        }
    }
}
