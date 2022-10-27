## Task 4

### Create 

1. Create another persistance project for Dapper as an ORM. Name it `Persistence.Dapper`.

2. Add some kind of Database context class like this one below.

```cs
 internal class DapperContext
    {
        public string ConnectionString { get; }

        public DapperContext()
        {
            this.ConnectionString = "<YOUR_CONNECTION_STRING>";
        }
    }
```

3. Create implementation for all repositories. Here an example of `VisitRepository`, adjust it to your own classes, properties.

```cs
    public class DapperVisitRepository : IVisitRepository
    {
        private const string GET_ALL_VISITS = @"SELECT t0.*, t1.*, t2.* FROM Visits t0
                    LEFT JOIN Patients t1 ON t1.Id = t0.PatientId
                    LEFT JOIN Doctors t2 ON t2.Id = t0.DoctorId ";

        private readonly DapperContext context = new DapperContext();
        public void Add(Visit visit)
        {
            using (var connection = new SqlConnection(context.ConnectionString))
            {
                connection.Execute("INSERT INTO Visits(DoctorId, PatientId, VisitDateTime) VALUES( @doctorId, @patientId," +
                    "@visitDateTime)", new { visit.DoctorId, visit.PatientId, visit.VisitDateTime });
            }
        }

        public IEnumerable<Visit> GetAll()
        {
            using (var connection = new SqlConnection(context.ConnectionString))
            {
                return connection.Query<Visit, Patient, Doctor, Visit>(GET_ALL_VISITS, (visit, patient, doctor) =>
                {
                    visit.Patient = patient;
                    visit.Doctor = doctor;

                    return visit;
                }, splitOn: "id, id");
            }
        }
    }
```

4. Switch repositories' implementations in the service responsible for making visits in `UI` project and use Dapper versions of repository. Inspect if something changes 
in comparison to EF version.
