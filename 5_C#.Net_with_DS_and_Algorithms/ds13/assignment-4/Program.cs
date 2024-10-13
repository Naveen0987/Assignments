using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

class Program
{
    static void Main()
    {
        XDocument xmlDoc = new XDocument(
            new XElement("Bookstore",
                new XElement("Book",
                    new XElement("Title", "Book 1"),
                    new XElement("Author", "John Doe"),
                    new XElement("Price", "880")
                ),
                new XElement("Book",
                    new XElement("Title", "Book 2"),
                    new XElement("Author", "Jane Doe"),
                    new XElement("Price", "800")
                ),
                new XElement("Book",
                    new XElement("Title", "Book 3"),
                    new XElement("Author", "John Doe"),
                    new XElement("Price", "104")
                )
            )
        );

        xmlDoc.Save("bookstore.xml");

        xmlDoc = XDocument.Load("bookstore.xml");

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