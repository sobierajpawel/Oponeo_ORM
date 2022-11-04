using Microsoft.EntityFrameworkCore;
using Oponeo.ManagementPatient.Domain.Model;
using Oponeo.ManagementPatient.Domain.Repositories;
using Oponeo.ManagementPatient.Persistence.EF.DatabaseContext;

namespace Oponeo.ManagementPatient.Persistence.EF.Repositories
{
    public class EFVisitsRepository : IVisitRepository
    {
        private PatientDbContext _patientDbContext;
        public EFVisitsRepository(PatientDbContext patientDbContext)
        {
            _patientDbContext = patientDbContext;   
        }

        public void AddVisit(Visit visit)
        {
            _patientDbContext.Visits.Add(visit);
            _patientDbContext.SaveChanges();
        }

        public IEnumerable<Visit> GetAll()
        {
            return _patientDbContext.Visits.Include(x=>x.Patient).Include(x=>x.Doctor);
        }
    }
}
