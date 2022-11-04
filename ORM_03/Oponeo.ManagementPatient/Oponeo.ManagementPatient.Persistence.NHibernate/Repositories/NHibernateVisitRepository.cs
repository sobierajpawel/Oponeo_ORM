using Oponeo.ManagementPatient.Domain.Model;
using Oponeo.ManagementPatient.Domain.Repositories;
using Oponeo.ManagementPatient.Persistence.NHibernate.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oponeo.ManagementPatient.Persistence.NHibernate.Repositories
{
    public class NHibernateVisitRepository : IVisitRepository
    {
        public void AddVisit(Visit visit)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                session.Save(visit);
                session.Flush();
            }
        }

        public IEnumerable<Visit> GetAll()
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                Patient p = null;
                Doctor d = null;

                return session.QueryOver<Visit>()
                    .JoinAlias(x => x.Patient, () => p)
                    .JoinAlias(x => x.Doctor, () => d)
                    .List<Visit>();
            }
        }
    }
}
