
using System;

class Person
{
    private string name;
    private string address;
    private double salary;

    // Constructor
    public Person(string name, string address, double salary)
    {
        this.name = name;
        this.address = address;
        this.salary = salary;
    }

    // Get va Set
    public string getName()
    {
        return name;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public string getAddress()
    {
        return address;
    }

    public void setAddress(string address)
    {
        this.address = address;
    }

    public double getSalary()
    {
        return salary;
    }

    public void setSalary(double salary)
    {
        this.salary = salary;
    }
}

class Program
{
    //thong tin Person - Nhapp
    static Person inputPersonInfo(string name, string address, string sSalary)
    {
        double salary;

        if (sSalary == "")
        {
            throw new Exception("You must input Salary.");
        }

        if (!double.TryParse(sSalary, out salary))
        {
            throw new Exception("You must input digit.");
        }

        if (salary <= 0)
        {
            throw new Exception("Salary is greater than zero");
        }

        Person person = new Person(name, address, salary);
        return person;
    }

    //thong tin Person - Hien thi
    static void displayPersonInfo(Person person)
    {
        Console.WriteLine("Name: " + person.getName());
        Console.WriteLine("Address: " + person.getAddress());
        Console.WriteLine("Salary: " + person.getSalary());
        Console.WriteLine();
    }

    //thong tin Person - Sap xep
    static Person[] sortBySalary(Person[] person)
    {
        if (person == null)
        {
            throw new Exception("Can't Sort Person");
        }

        for (int i = 0; i < person.Length - 1; i++)
        {
            for (int j = 0; j < person.Length - 1 - i; j++)
            {
                if (person[j].getSalary() > person[j + 1].getSalary())
                {
                    Person temp = person[j];
                    person[j] = person[j + 1];
                    person[j + 1] = temp;
                }
            }
        }

        return person;
    }

    static void Main(string[] args)
    {
        Person[] person = new Person[3];

        Console.WriteLine("=====Management Person programer=====");

        // Function 1: Nhap thong tin 3 nguoi
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("\nInput Information of Person");

            Console.Write("Please input name: ");
            string name = Console.ReadLine();

            Console.Write("Please input address: ");
            string address = Console.ReadLine();

            while (true)
            {
                Console.Write("Please input salary: ");
                string sSalary = Console.ReadLine();

                try
                {
                    person[i] = inputPersonInfo(name, address, sSalary);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        // Function 2: Hien thi thong tin da nhap
        Console.WriteLine("\nInformation of Person you have entered:");

        for (int i = 0; i < 3; i++)
        {
            displayPersonInfo(person[i]);
        }

        // Function 3: Sap xep va hien thi
        try
        {
            person = sortBySalary(person);

            Console.WriteLine("Information of Person sorted by salary:");

            for (int i = 0; i < 3; i++)
            {
                displayPersonInfo(person[i]);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
