using Oponeo.ManagementPatient.Domain.Model;

namespace Oponeo.ManagementPatient.Domain.Repositories
{
    public interface IPatientRepository
    {
        Patient GetById(int id);
        IEnumerable<Patient> GetAll();
        void Add(Patient doctor);
        void Update(Patient doctor);
        void Delete(int id);
    }
}
