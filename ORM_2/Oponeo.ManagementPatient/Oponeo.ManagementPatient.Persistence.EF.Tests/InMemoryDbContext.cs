using Microsoft.EntityFrameworkCore;
using Oponeo.ManagementPatient.Persistence.EF.DatabaseContext;

namespace Oponeo.ManagementPatient.Persistence.EF.Tests
{
    internal class InMemoryDbContext
    {
        public PatientDbContext GetMemoryContext()
        {
            var options = new DbContextOptionsBuilder<PatientDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            return new PatientDbContext(options);
        }
    }
}
