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
        }

        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
    }
}
