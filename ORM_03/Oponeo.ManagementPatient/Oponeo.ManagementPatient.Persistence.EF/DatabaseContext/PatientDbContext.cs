using Microsoft.EntityFrameworkCore;
using Oponeo.ManagementPatient.Domain.Model;
using System.Diagnostics;

namespace Oponeo.ManagementPatient.Persistence.EF.DatabaseContext
{
    public class PatientDbContext : DbContext
    {
        private readonly bool _isProductionDb;

        public PatientDbContext()
        {
            _isProductionDb = true;
        }

        public PatientDbContext(DbContextOptions<PatientDbContext> options)
            : base(options)
        {
            _isProductionDb = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (_isProductionDb)
            {
                dbContextOptionsBuilder
                    .LogTo(message => Debug.WriteLine(message))
                    .UseSqlServer("data source=WS-140P9K3;initial catalog=Patient_Db_Management;user id=sa;password=SQL2019_adm;MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Doctor>()
            //    .HasData(
            //        new Doctor { FirstName = "Jan", LastName = "Doctor", Id = -1});

            //modelBuilder.Entity<Patient>()
            //    .HasData(
            //        new Patient { FirstName = "Adam", LastName = "Patient", Id = -1 });

            //[Key]
            modelBuilder.Entity<Visit>().HasKey(x => x.Id);
            modelBuilder.Entity<Patient>().HasKey(x => x.Id);
            modelBuilder.Entity<Doctor>().HasKey(x => x.Id);

            //[Required] - Patient
            modelBuilder.Entity<Patient>()
                .Property(x => x.FirstName).IsRequired();
            modelBuilder.Entity<Patient>()
                .Property(x => x.LastName).IsRequired();
            //[Required] - Doctor
            modelBuilder.Entity<Doctor>()
                .Property(x => x.FirstName).IsRequired();
            modelBuilder.Entity<Doctor>()
                .Property(x => x.LastName).IsRequired();

            //Foreign keys
            modelBuilder.Entity<Visit>()
                .HasOne(x => x.Patient)
                .WithMany(x => x.Visits);

            //modelBuilder.Entity<Patient>()
            //    .HasMany(x => x.Visits)
            //    .WithOne(x => x.Patient);

            modelBuilder.Entity<Visit>()
                .HasOne(x => x.Doctor)
                .WithMany(x => x.Visits);

            //modelBuilder.Entity<Doctor>()
            //    .HasMany(x => x.Visits)
            //    .WithOne(x => x.Doctor);

            modelBuilder.Entity<Patient>().Property<DateTime?>("CreatedDateTime");
            modelBuilder.Entity<Patient>().Property<DateTime?>("UpdatedDateTime");
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
    }
}
