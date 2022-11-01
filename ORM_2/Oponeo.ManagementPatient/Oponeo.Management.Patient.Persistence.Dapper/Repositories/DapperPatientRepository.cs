using Dapper;
using Microsoft.Data.SqlClient;
using Oponeo.ManagementPatient.Domain.Repositories;
using Oponeo.ManagementPatient.Domain.Model;

namespace Oponeo.ManagementPatient.Persistence.Dapper.Repositories
{
    public class DapperPatientRepository : IPatientRepository
    {
        private readonly DbDapperContext dbDapperContext = new DbDapperContext();
        private const string GET_PATIENT_BY_ID = "SELECT TOP(1) * FROM Patients WHERE Id = @id_new";

        public void Add(ManagementPatient.Domain.Model.Patient doctor)
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
            using (var connection = new SqlConnection(dbDapperContext.ConnectionString))
            {
                return connection.QueryFirst<Patient>(GET_PATIENT_BY_ID, new { id_new = id });
            }
        }

        public void Update(ManagementPatient.Domain.Model.Patient doctor)
        {
            throw new NotImplementedException();
        }
    }
}
