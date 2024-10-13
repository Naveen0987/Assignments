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
            new Person { FirstName = "Naveen", LastName = "Ch", Age = 22 },
        };

        var personsOver30 = persons.Where(p => p.Age > 30).Select(p => $"{p.FirstName} {p.LastName}");
        Console.WriteLine("Persons over 30:");
        foreach (var person in personsOver30)
        {
            Console.WriteLine(person);
        }

        var sortedPersons = persons.OrderBy(p => p.LastName).ThenBy(p => p.FirstName);
        Console.WriteLine("\nSorted persons:");
        foreach (var person in sortedPersons)
        {
            Console.WriteLine($"{person.FirstName} {person.LastName}");
        }
    }
}