using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oponeo.EF_CodeFirst.ConsoleApp.Model
{
    [Table("Customers")]
    public class Customer : BaseEntity
    {
        [StringLength(50)]
        public string? CustomerName { get; set; }

        [StringLength(255)]
        public string? Address { get; set; }

        public string? Description { get; set; }

        public string? TaxIdentifier { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
