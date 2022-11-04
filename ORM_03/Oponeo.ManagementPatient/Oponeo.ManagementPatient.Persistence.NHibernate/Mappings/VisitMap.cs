using FluentNHibernate.Mapping;
using Oponeo.ManagementPatient.Domain.Model;

namespace Oponeo.ManagementPatient.Persistence.NHibernate.Mappings
{
    internal class VisitMap : ClassMap<Visit>
    {
        public VisitMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.VisitDateTime);
            Map(x => x.Description);
            References(x => x.Patient);
            References(x => x.Doctor);
            Table("Visits");
        }
    }
}
