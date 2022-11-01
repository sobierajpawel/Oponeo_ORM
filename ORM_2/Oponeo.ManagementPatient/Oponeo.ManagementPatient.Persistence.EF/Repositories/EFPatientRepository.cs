using Oponeo.ManagementPatient.Domain.Model;
using Oponeo.ManagementPatient.Domain.Repositories;
using Oponeo.ManagementPatient.Persistence.EF.DatabaseContext;

namespace Oponeo.ManagementPatient.Persistence.EF.Repositories
{
    public class EFPatientRepository : IPatientRepository
    {
        private readonly PatientDbContext _context;

        public EFPatientRepository(PatientDbContext context)
        {
            _context = context; 
        }

        public void Add(Patient doctor)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public Patient GetById(int id)
        {
            return _context.Patients.Where(x => x.Id == id).Single();
        }

        public void Update(Patient doctor)
        {
            throw new NotImplementedException();
        }
    }
}
