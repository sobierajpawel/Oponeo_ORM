using Oponeo.ManagementPatient.Domain.Model;

namespace Oponeo.ManagementPatient.Domain.Repositories
{
    public interface IVisitRepository
    {
        IEnumerable<Visit> GetAll();
        void AddVisit(Visit visit);
    }
}
