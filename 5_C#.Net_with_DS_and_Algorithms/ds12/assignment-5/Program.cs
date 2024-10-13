using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public decimal Salary { get; set; }
}

class Program
{
    static void Main()
    {
        List<Person> persons = new List<Person>
        {
            new Person { FirstName = "Mahesh", LastName = "M", Age = 33 },
            new Person { FirstName = "Charan", LastName = "K", Age = 28 },
            new Person { FirstName = "ravi", LastName = "S", Age = 36 },
            new Person { FirstName = "Surya", LastName = "R", Age = 32 },
            new Person { FirstName = "Naveen", LastName = "Ch", Age = 22},
        };

        Console.WriteLine("Ages:");
        PrintAges(persons);

        Console.WriteLine("\nPersons:");
        PrintPersons(persons);

        Console.WriteLine("\nNames:");
        PrintNames(persons);
    }

    static void PrintAges(List<Person> persons)
    {
        foreach (var person in persons)
        {
            Console.WriteLine(person.Age);
        }
    }

    static void PrintPersons(List<Person> persons)
    {
        foreach (var person in persons)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName} {person.Age}");
        }
    }

    static void PrintNames(List<Person> persons)
    {
        foreach (var person in persons)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}");
        }
    }
}