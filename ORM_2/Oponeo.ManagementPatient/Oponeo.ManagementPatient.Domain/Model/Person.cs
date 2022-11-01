using System.ComponentModel.DataAnnotations;

namespace Oponeo.ManagementPatient.Domain.Model
{
    public abstract class Person
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }
    }
}
