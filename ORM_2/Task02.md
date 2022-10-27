## Task 2

### Create an onion architecture for EF

1. Create 'Core' project when you add entities for `Patient`, `Doctor` and `Visit`. Patients should have id, first_name, last_name as well as doctors. Visits should have id, 
datetime and references to `Doctor` and `Patient`.

2. Create interfaces for repositories in `Core` project.

```cs
public interface IDoctorRepository
    {
        Doctor GetById(int id);
        IEnumerable<Doctor> GetAll();
        void Add(Doctor patient);
        void Update(Doctor patient);
        void Remove(Doctor patient);
    }
```


```cs
 public interface IPatientRepository
    {
        Patient GetPatientById(int id);
        IEnumerable<Patient> GetAll();
        void Add(Patient patient);
        void Update(Patient patient);
        void Remove(Patient patient);
    }
```

```cs
  public interface IVisitRepository
    {
        IEnumerable<Visit> GetAll();
        void Add(Visit visit);

    }
```

3. Add `Service` project which has a class for creating visit. It may contain class similar to this one:

```cs
 public class VisitCalendarService
    {
        private readonly IPatientRepository patientRepository;
        private readonly IDoctorRepository doctorRepository;
        private readonly IVisitRepository visitRepository;
        
        public VisitCalendarService(IPatientRepository patientRepository, IDoctorRepository doctorRepository,
            IVisitRepository visitRepository)
        {
            this.visitRepository = visitRepository;
            this.patientRepository = patientRepository;
            this.doctorRepository = doctorRepository;
        }
        public Visit MakeVisit(Doctor doctor, Patient patient, DateTime dateTimeVisit)
        {
            var doctorAssignedToVisit = this.doctorRepository.GetById(doctor.Id);
            if (doctorAssignedToVisit == null)
            {
                throw new ArgumentException("Doctor not found");
            }

            var patientAssignedToVisit = this.patientRepository.GetPatientById(patient.Id);

            if (patientAssignedToVisit == null)
            {
                throw new ArgumentException("Patient not found");
            }

            Visit visit = new Visit
            {
                DoctorId = doctorAssignedToVisit.Id,
                PatientId = patientAssignedToVisit.Id,
                VisitDateTime = dateTimeVisit
            };

            visitRepository.Add(visit);

            return visit;
        }

        public IEnumerable<Visit> GetAllVisitsWithDetails()
        {
            return visitRepository.GetAll();
        }

    }
```

4. Create an UI project which adds visit for doctor and patient.

5. Create `Persistence.EF` project which will have all implementation of interfaces of repositories.

6.  Use migrations to create database and write db context.

```cs
internal class PatientDbContext : DbContext
    {
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder
                .LogTo(message => Debug.WriteLine(message))
                .UseSqlServer(<Connection_string>);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<Visit>().ToTable("Visits");
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && (
                    x.State == EntityState.Added || x.State == EntityState.Modified
                ));

            foreach (var entity in entries)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedDateTime = DateTime.UtcNow;
                }
                else if (entity.State == EntityState.Modified)
                {
                    ((BaseEntity)entity.Entity).UpdateDateTime = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }
    }
```
    
 7. Provide implementations of repositories to the UI when service is invoked.
