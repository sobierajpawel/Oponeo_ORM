using FluentNHibernate.Mapping;
using Oponeo.ManagementPatient.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oponeo.ManagementPatient.Persistence.NHibernate.Mappings
{
    internal class DoctorMap : ClassMap<Doctor>
    {
        public DoctorMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Table("Doctors");
        }
    }
}
