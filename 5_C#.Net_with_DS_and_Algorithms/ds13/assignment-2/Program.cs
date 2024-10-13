using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Naveen", Gender = "Male", Age = 30, Pincode = "123456" },
            new Customer { Id = 2, Name = "Siva", Gender = "Male", Age = 25, Pincode = "789012" },
            new Customer { Id = 3, Name = "Mahesh", Gender = "Male", Age = 28, Pincode = "345678" },
            new Customer { Id = 4, Name = "Surya", Gender = "Male", Age = 22, Pincode = "901234" },
            new Customer { Id = 5, Name = "Charan", Gender = "Male", Age = 26, Pincode = "567890" }
        };

        List<Order> orders = new List<Order>
        {
            new Order { OrderId = 1, Address = "Address 1", Datetime = DateTime.Now, CustomerId = 1 },
            new Order { OrderId = 2, Address = "Address 2", Datetime = DateTime.Now, CustomerId = 2 },
            new Order { OrderId = 3, Address = "Address 3", Datetime = DateTime.Now, CustomerId = 3 },
            new Order { OrderId = 4, Address = "Address 4", Datetime = DateTime.Now, CustomerId = 4 },
            new Order { OrderId = 5, Address = "Address 5", Datetime = DateTime.Now, CustomerId = 5 }
        };

        // Print customer list
        Console.WriteLine("Customer List:");
        foreach (var customer in customers)
        {
            Console.WriteLine($"Id: {customer.Id}, Name: {customer.Name}, Gender: {customer.Gender}, Age: {customer.Age}, Pincode: {customer.Pincode}");
        }

        var innerJoinResult = Joins.InnerJoin(orders, customers);
        var leftJoinResult = Joins.LeftJoin(orders, customers);
        var leftToRightJoinResult = Joins.LeftToRightJoin(orders, customers);
        var rightToLeftJoinResult = Joins.RightToLeftJoin(orders, customers);

        Console.WriteLine("\nInner Join Result:");
        foreach (var order in innerJoinResult)
        {
            Console.WriteLine(
                $"OrderId: {order.OrderId}, " +
                $"Address: {order.Address}, " +
                $"Datetime: {order.Datetime}, " +
                $"CustomerName: {order.Name}"
            );
        }

        Console.WriteLine("\nLeft Join Result:");
        foreach (var order in leftJoinResult)
        {
            Console.WriteLine(
                $"OrderId: {order.OrderId}, " +
                $"Address: {order.Address}, " +
                $"Datetime: {order.Datetime}, " +
                $"CustomerName: {order.Name}"
            );
        }

        Console.WriteLine("\nLeft to Right Join Result:");
        foreach (var order in leftToRightJoinResult)
        {
            Console.WriteLine(
                $"OrderId: {order.OrderId}, " +
                $"Address: {order.Address}, " +
                $"Datetime: {order.Datetime}, " +
                $"CustomerName: {order.Name}"
            );
        }

        Console.WriteLine("\nRight to Left Join Result:");
        foreach (var order in rightToLeftJoinResult)
        {
            Console.WriteLine(
                $"OrderId: {order.OrderId}, " +
                $"Address: {order.Address}, " +
                $"Datetime: {order.Datetime}, " +
                $"CustomerName: {order.Name}"
            );
        }
    }
}
