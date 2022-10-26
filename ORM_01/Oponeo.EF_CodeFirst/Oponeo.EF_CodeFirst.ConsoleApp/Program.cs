// See https://aka.ms/new-console-template for more information
using Oponeo.EF_CodeFirst.ConsoleApp.Infrastrucure;
using Oponeo.EF_CodeFirst.ConsoleApp.Model;

Console.WriteLine("Hello, EF code-first approach!");

//using (var context = new OrdersDbContext())
//{
//    //context.Database.EnsureDeleted();
//    //context.Database.EnsureCreated();
    
//    //Console.WriteLine("The database was successfuly created");

//    var customer = new Customer
//    {
//        Address = "Test adres",
//        CustomerName = "Customer no 2",
//        Description = "Test",
//    };

//    context.Customers.Add(customer);
//    context.SaveChanges();
//}

using (var context = new OrdersDbContext())
{
    var customers = context.Customers.ToList();

    foreach(var customer in customers)
    {
        Console.WriteLine($"Id:{customer.Id}, Name: {customer.CustomerName}");

        foreach (var order in customer.Orders)
        {
            Console.WriteLine($"Id:{order.Id}");
        }
    }
}

Console.ReadKey();