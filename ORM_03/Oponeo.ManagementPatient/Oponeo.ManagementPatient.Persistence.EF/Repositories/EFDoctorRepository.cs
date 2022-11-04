using Oponeo.ManagementPatient.Domain.Model;
using Oponeo.ManagementPatient.Domain.Repositories;
using Oponeo.ManagementPatient.Persistence.EF.DatabaseContext;

namespace Oponeo.ManagementPatient.Persistence.EF.Repositories
{
    public class EFDoctorRepository : IDoctorRepository
    {
        private readonly PatientDbContext _context;
        public EFDoctorRepository(PatientDbContext patientDbContext)
        {
            this._context = patientDbContext;
        }

        public void Add(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }

        public Doctor GetById(int id)
        {
            return _context.Doctors.Where(x => x.Id == id).Single();
        }

        public void Update(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
