using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        XDocument xmlDoc = XDocument.Load("bookstore.xml");

        var johnDoeBooks = from book in xmlDoc.Descendants("Book")
                           where book.Element("Author").Value == "John Doe"
                           select book.Element("Title").Value;

        Console.WriteLine("Books authored by John Doe:");
        foreach (var title in johnDoeBooks)
        {
            Console.WriteLine(title);
        }

        var averagePrice = xmlDoc.Descendants("Book")
                                 .Average(book => decimal.Parse(book.Element("Price").Value));

        Console.WriteLine($"Average price of all books: {averagePrice:C}");
    }
}