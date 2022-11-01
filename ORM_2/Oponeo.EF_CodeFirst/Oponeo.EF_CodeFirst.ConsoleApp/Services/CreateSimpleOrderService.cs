using Oponeo.EF_CodeFirst.ConsoleApp.Infrastrucure;
using Oponeo.EF_CodeFirst.ConsoleApp.Model;

namespace Oponeo.EF_CodeFirst.ConsoleApp.Services
{
    internal class CreateSimpleOrderService
    {
        public void CreateOrder(int customerId, IList<OrderLine> orderLines)
        {
            if (orderLines == null || !orderLines.Any())
            {
                throw new ArgumentException("OrderLines should contain at least one item");
            }

            using (var context = new OrdersDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var line in orderLines)
                        {
                            var product = context.Products.Where(x => x.ProductName == line.Product.ProductName).FirstOrDefault();

                            if (product == null)
                            {
                                context.Products.Add(line.Product);
                                context.SaveChanges();
                            }
                        }

                        var order = new Order
                        {
                            OrderLines = orderLines,
                            CustomerId = 600,
                            OrderNumber = $"{DateTime.Now.ToString("ddMMyyyyHHmmss")}"
                        };
                        context.Orders.Add(order);
                        context.SaveChanges();

                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        
                    }
                }
            }
        }
    }
}
