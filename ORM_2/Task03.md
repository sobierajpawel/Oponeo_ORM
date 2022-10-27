## Task 3

### Create unit tests with InMemory Database and EF

1. Change DbContext in such a way you will be able to use another constructor with DbContextOption.

```cs
   private readonly bool isInMemoryDb;
   public PatientDbContext()
        {
            isInMemoryDb = false;
        }


        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options) {
            isInMemoryDb = true;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!isInMemoryDb)
            {
                dbContextOptionsBuilder
                    .LogTo(message => Debug.WriteLine(message))
                    .UseSqlServer(<YOUR_CONNECTION_STRING>);
            }
        }
 ```
 
 2. Modify if needed your repository that you will be able to inject the context of the database instead of using `using` statement e.g.

```cs
 public class VisitRepository : IVisitRepository
    {
        private readonly PatientDbContext context;
        public VisitRepository(PatientDbContext patientDbContext)
        {
            context = patientDbContext;
        }

        public void Add(Visit visit)
        {
                context.Visits.Add(visit);
                context.SaveChanges();
        }

        public IEnumerable<Visit> GetAll()
        {
            return context.Visits.Include(x => x.Patient)
                    .Include(x => x.Doctor);

        }
    }
```

3. Write unit tests to cover all methods in `VisitsRepository`. Use whatever unit testing framework you want. Here a sample of seeting database in memory in `NUnit`.

```cs
  public PatientDbContext GetMemoryContext()
        {
            var options = new DbContextOptionsBuilder<PatientDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;
            return new PatientDbContext(options);
        }

        [SetUp]
        public void Setup()
        {
            var db = GetMemoryContext();
            db.Doctors.Add(new Doctor { FirstName = "Test", LastName = "Test" });
            db.Patients.Add(new Patient { FirstName = "Test", LastName = "Test" });

            db.Visits.Add(new Visit { PatientId = 1, DoctorId = 1, VisitDateTime = DateTime.Now });
            db.Visits.Add(new Visit { PatientId = 1, DoctorId = 1, VisitDateTime = DateTime.Now });

            db.SaveChanges();
        }
 ```
