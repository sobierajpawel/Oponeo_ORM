using Oponeo.ManagementPatient.Domain.Model;

namespace Oponeo.ManagementPatient.Domain.Repositories
{
    public interface IDoctorRepository
    {
        Doctor GetById(int id);
        IEnumerable<Doctor> GetAll();
        void Add(Doctor doctor);
        void Update(Doctor doctor);
        void Delete(int id);
    }
}
