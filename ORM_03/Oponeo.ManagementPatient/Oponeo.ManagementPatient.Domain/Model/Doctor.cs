using System.ComponentModel.DataAnnotations;

namespace Oponeo.ManagementPatient.Domain.Model
{
    public class Doctor : Person
    {
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
