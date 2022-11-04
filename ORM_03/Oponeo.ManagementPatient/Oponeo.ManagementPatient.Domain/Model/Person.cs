using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oponeo.ManagementPatient.Domain.Model
{
    public abstract class Person
    {
        public virtual int Id { get; set; }

        public virtual string? FirstName { get; set; }

        public virtual string? LastName { get; set; }

    }
}
