using System.ComponentModel.DataAnnotations;

namespace Oponeo.EF_CodeFirst.ConsoleApp.Model
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime? CreatedDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}
