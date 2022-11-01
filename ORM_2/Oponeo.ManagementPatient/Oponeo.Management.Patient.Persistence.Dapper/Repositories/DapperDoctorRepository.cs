using Dapper;
using Microsoft.Data.SqlClient;
using Oponeo.ManagementPatient.Domain.Model;
using Oponeo.ManagementPatient.Domain.Repositories;

namespace Oponeo.ManagementPatient.Persistence.Dapper.Repositories
{
    public class DapperDoctorRepository : IDoctorRepository
    {
        private readonly DbDapperContext dbDapperContext = new DbDapperContext();
        private const string GET_DOCTOR_BY_ID = "SELECT TOP(1) * FROM Doctors WHERE Id = @id_new";
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
            throw new NotImplementedException();
        }

        public Doctor GetById(int id)
        {
            using (var connection = new SqlConnection(dbDapperContext.ConnectionString))
            {
                return connection.QueryFirst<Doctor>(GET_DOCTOR_BY_ID, new { id_new = id });
            }
        }

        public void Update(Doctor doctor)
        {
            throw new NotImplementedException();
        }
    }
}
