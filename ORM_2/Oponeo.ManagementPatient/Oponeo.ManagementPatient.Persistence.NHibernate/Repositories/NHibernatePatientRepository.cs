using NHibernate;
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
    public class NHibernatePatientRepository : IPatientRepository
    {
        public void Add(Patient patient)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                session.Save(patient);
                session.Flush();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAll()
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                return session.Query<Patient>().ToList();
            }
        }

        public Patient GetById(int id)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                return session.Get<Patient>(id);
            }
        }

        public void Update(Patient doctor)
        {
            throw new NotImplementedException();
        }
    }
}
