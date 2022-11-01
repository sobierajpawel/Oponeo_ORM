using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oponeo.EF_CodeFirst.ConsoleApp.Model
{
    public class Order : BaseEntity
    {
        [StringLength(50)]
        public string OrderNumber { get; set; }

        public string? Description { get; set; }

        public string? Description2 { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
