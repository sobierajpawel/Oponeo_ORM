using Oponeo.ManagementPatient.Domain.Model;
using Oponeo.ManagementPatient.Domain.Repositories;

namespace Oponeo.ManagementPatient.Application
{
    public class VisitCalendarService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IVisitRepository _visitRepository;
        public VisitCalendarService(IDoctorRepository doctorRepository, IPatientRepository patientRepository, IVisitRepository visitRepository)
        {
            this._doctorRepository = doctorRepository ?? throw new ArgumentNullException(nameof(doctorRepository));
            this._patientRepository = patientRepository ?? throw new ArgumentNullException(nameof(patientRepository));
            this._visitRepository = visitRepository ?? throw new ArgumentNullException(nameof(visitRepository));
        }

        public void MakeVisit(int doctorId, int patientId, DateTime visitDateTime)
        {
            var doctorAssignedToVisit = _doctorRepository.GetById(doctorId);
            if (doctorAssignedToVisit == null)
            {
                throw new ArgumentException("DoctorId not found in database");
            }

            var patientAssignedToVisit = _patientRepository.GetById(patientId);
            if (patientAssignedToVisit == null)
            {
                throw new ArgumentException("PatientId not found in database");
            }

            Visit visit = new()
            {
                DoctorId = doctorAssignedToVisit.Id,
                PatientId = patientAssignedToVisit.Id,
                VisitDateTime = visitDateTime
            };

            _visitRepository.AddVisit(visit);
        }
    }
}
