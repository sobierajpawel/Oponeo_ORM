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
    public class NHibernateDoctorRepository : IDoctorRepository
    {
        public void Add(Doctor doctor)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                session.Save(doctor);
                session.Flush();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAll()
        {
            using (ISession session = FluentNHibernateHelper.OpenSession())
            {
                return session.Query<Doctor>().ToList();
            }
        }

        public Doctor GetById(int id)
        {
            using (var session = FluentNHibernateHelper.OpenSession())
            {
                return session.Get<Doctor>(id);
            }
        }

        public void Update(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
