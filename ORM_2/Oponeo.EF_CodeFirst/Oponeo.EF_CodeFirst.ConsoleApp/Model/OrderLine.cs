using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oponeo.EF_CodeFirst.ConsoleApp.Model
{
    public class OrderLine
    {
        [ForeignKey("Order")]
        public int OderId { get; set; }

        public int LineNumber { get; set; }

        public double NetPrice { get; set; }

        public double GrossPrice { get; set; }

        public double Quantity { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
