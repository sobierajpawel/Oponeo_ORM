namespace Oponeo.ManagementPatient.Domain.Model
{
    public class Patient : Person
    {
        public virtual DateTime BirthDate { get; set; }

        public virtual ICollection<Visit> Visits { get; set; }
    }
}
