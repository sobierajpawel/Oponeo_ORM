using FluentNHibernate.Mapping;
using Oponeo.ManagementPatient.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oponeo.ManagementPatient.Persistence.NHibernate.Mappings
{
    internal class PatientMap : ClassMap<Patient>
    {
        public PatientMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.FirstName).Length(50);
            Map(x => x.LastName).Length(50);
            Map(x => x.BirthDate).Column("DateOfBirth");
            Table("Patients");
        }
    }
}
