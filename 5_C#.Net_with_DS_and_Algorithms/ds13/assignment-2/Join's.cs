using System.Collections.Generic;
using System.Linq;

public static class Joins
{
    public static IEnumerable<dynamic> InnerJoin(List<Order> orders, List<Customer> customers)
    {
        return orders
            .Join(
                customers,
                o => o.CustomerId,
                c => c.Id,
                (o, c) => new { o.OrderId, o.Address, o.Datetime, c.Name }
            );
    }

    public static IEnumerable<dynamic> LeftJoin(List<Order> orders, List<Customer> customers)
    {
        return orders
            .GroupJoin(
                customers,
                o => o.CustomerId,
                c => c.Id,
                (o, c) => new { o, c }
            )
            .SelectMany(
                x => x.c.DefaultIfEmpty(),
                (x, c) => new { x.o.OrderId, x.o.Address, x.o.Datetime, Name = c?.Name }
            );
    }

    public static IEnumerable<dynamic> LeftToRightJoin(List<Order> orders, List<Customer> customers)
    {
        return orders
            .GroupJoin(
                customers,
                o => o.CustomerId,
                c => c.Id,
                (o, c) => new { o, Customer = c.DefaultIfEmpty().FirstOrDefault() }
            )
            .Select(x => new { x.o.OrderId, x.o.Address, x.o.Datetime, Name = x.Customer?.Name });
    }

    public static IEnumerable<dynamic> RightToLeftJoin(List<Order> orders, List<Customer> customers)
    {
        return customers
            .GroupJoin(
                orders,
                c => c.Id,
                o => o.CustomerId,
                (c, o) => new { c, Order = o.DefaultIfEmpty().FirstOrDefault() }
            )
            .Select(x => new { x.Order?.OrderId, x.Order?.Address, x.Order?.Datetime, Name = x.c.Name });
    }
}
