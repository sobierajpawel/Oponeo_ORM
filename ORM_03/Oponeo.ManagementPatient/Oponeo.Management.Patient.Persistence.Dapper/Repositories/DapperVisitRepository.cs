using Dapper;
using Microsoft.Data.SqlClient;
using Oponeo.ManagementPatient.Domain.Model;
using Oponeo.ManagementPatient.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oponeo.ManagementPatient.Persistence.Dapper.Repositories
{
    public class DapperVisitRepository : IVisitRepository
    {
        private readonly DbDapperContext dbDapperContext = new DbDapperContext();
        private const string INSERT_VISIT = "INSERT INTO Visits(DoctorId, PatientId, VisitDateTime) VALUES" +
            " (@doctorId, @patientId, @visitDateTime)";
        private const string SELECT_ALL_VISITS = @"SELECT * FROM Visits t0 
                        LEFT JOIN Patients t1 ON t0.PatientId = t1.Id 
                        LEFT JOIN Doctors t2 ON t0.DoctorId = t2.Id";

        public void AddVisit(Visit visit)
        {
            using (var connection = new SqlConnection(dbDapperContext.ConnectionString))
            {
                connection.Execute(INSERT_VISIT, new
                {
                    doctor = visit.Doctor,
                    patient = visit.Patient,
                    visitDateTime = visit.VisitDateTime
                });
            }
        }

        public IEnumerable<Visit> GetAll()
        {
            using (var connection = new SqlConnection(dbDapperContext.ConnectionString))
            {
                var visits = connection.Query<Visit, Patient, Doctor, Visit>(SELECT_ALL_VISITS, (visit, patient, doctor) =>
                {
                    visit.Patient = patient;
                    visit.Doctor = doctor;
                    return visit;
                });

                return visits;
            }
        }
    }
}
