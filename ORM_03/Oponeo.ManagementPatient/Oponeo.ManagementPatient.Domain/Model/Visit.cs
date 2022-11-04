using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Oponeo.ManagementPatient.Domain.Model
{
    public class Visit
    {
        public virtual int Id { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient {get;set;}
    
        public virtual DateTime VisitDateTime { get; set; }

        public virtual string? Description { get; set; }
    }
}
