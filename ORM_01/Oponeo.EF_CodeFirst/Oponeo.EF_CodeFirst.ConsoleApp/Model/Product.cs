using System.ComponentModel.DataAnnotations.Schema;

namespace Oponeo.EF_CodeFirst.ConsoleApp.Model
{
    public class Product : BaseEntity
    {

        public string ProductName { get; set; }
    }
}
