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
            new Person { FirstName = "Mahesh", LastName = "M", Age = 35 },
            new Person { FirstName = "Charan", LastName = "K", Age = 28 },
            new Person { FirstName = "ravi", LastName = "S", Age = 40 },
            new Person { FirstName = "Surya", LastName = "R", Age = 32 },
            new Person { FirstName = "Naveen", LastName = "Ch", Age = 25 },
        };

        var averageAge = persons.Average(p => p.Age);
        Console.WriteLine($"Average age: {averageAge}");

        var oldestPerson = persons.OrderByDescending(p => p.Age).First();
        var youngestPerson = persons.OrderBy(p => p.Age).First();

        Console.WriteLine($"Oldest person: {oldestPerson.FirstName} {oldestPerson.LastName} Age {oldestPerson.age}");
        Console.WriteLine($"Youngest person: {youngestPerson.FirstName} {youngestPerson.LastName} +  {youngestPerson.Age}");
    }
}