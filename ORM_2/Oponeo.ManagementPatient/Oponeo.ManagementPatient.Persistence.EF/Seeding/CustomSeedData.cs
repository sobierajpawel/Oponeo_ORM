using Oponeo.ManagementPatient.Persistence.EF.DatabaseContext;

namespace Oponeo.ManagementPatient.Persistence.EF.Seeding
{
    public class CustomSeedData
    {
        private readonly PatientDbContext _patientDbContext;
        public CustomSeedData(PatientDbContext patientDbContext)
        {
            this._patientDbContext = patientDbContext;
        }

        public void SeedDoctors()
        {
            if (_patientDbContext.Doctors.Where(x => x.FirstName == "Adam" && x.LastName == "Doctor").Any())
                return;

            _patientDbContext.Doctors.Add(new Domain.Model.Doctor
            {
                FirstName = "Adam",
                LastName = "Doctor"
            });

            _patientDbContext.SaveChanges();
        }
    }
}
