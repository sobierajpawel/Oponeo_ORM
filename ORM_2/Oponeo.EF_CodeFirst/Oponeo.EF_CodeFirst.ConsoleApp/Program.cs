// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Oponeo.EF_CodeFirst.ConsoleApp.Infrastrucure;
using Oponeo.EF_CodeFirst.ConsoleApp.Model;
using Oponeo.EF_CodeFirst.ConsoleApp.Services;

Console.WriteLine("Hello, EF code-first approach!");

//using (var context = new OrdersDbContext())
//{
//    //context.Database.EnsureDeleted();
//    //context.Database.EnsureCreated();

//    //Console.WriteLine("The database was successfuly created");

//    for (int i = 0; i < 10; i++)
//    {
//        var customer = new Customer
//        {
//            Address = "Test adres",
//            CustomerName = $"Customer no {i+1}",
//            Description = "Test",
//        };

//        context.Customers.Add(customer);
//    }

//    context.SaveChanges();
//}

//using (var context = new OrdersDbContext())
//{
//    //var customers = context.Customers.ToList();

//    var customerMethodSyntax = context.Customers.Where(x => x.CustomerName == "Customer no 1").ToList();

//    string parameter = "Customer no 1; ";
//    var customers = context.Customers.FromSqlRaw("SELECT * FROM Customers WHERE CustomerName = '" + parameter + "'").ToList();

//    var sqlParameter = new SqlParameter("@customerName", "Customer no 1");

//    var customersSelectedRaw = context
//        .Customers
//        .FromSqlRaw("SELECT * FROM Customers WHERE CustomerName = @customerName", sqlParameter)
//        .ToList();


//    var customerInterpolated = context
//        .Customers
//        .FromSqlInterpolated($"SELECT * FROM Customers WHERE CustomerName = {parameter}")
//        .ToList();

//    var customersMixedRawSqlWithLinq = context.Customers.FromSqlRaw("SELECT * FROM Customers").Where(x => x.CustomerName == parameter).ToList();

//    foreach (var customer in customers)
//    {
//        Console.WriteLine($"Id:{customer.Id}, Name: {customer.CustomerName}");

//        foreach (var order in customer.Orders)
//        {
//            Console.WriteLine($"Id:{order.Id}");
//        }
//    }
//}

//using (var context = new OrdersDbContext())
//{
//    IQueryable<Customer> customersQueryable = context.Customers.Where(x => x.CustomerName.StartsWith("Customer"));
//    //...
//    var resultQueryable = customersQueryable.Take(5).ToList();

//    IEnumerable<Customer> customersEnumerable = context.Customers.Where(x => x.CustomerName.StartsWith("Customer"));
//    //...
//    var resultEnumaerable = customersEnumerable.Take(5).ToList();
//}

CreateSimpleOrderService createSimpleOrderService = new();
createSimpleOrderService.CreateOrder(3, new List<OrderLine>
{
    new OrderLine
    {
        Product = new Product
        {
            ProductName = "Product 2"
        },
        Quantity = 1,
        NetPrice = 100,
        GrossPrice = 123
    }
});

Console.ReadKey();