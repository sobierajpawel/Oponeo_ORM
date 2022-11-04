using Oponeo.ManagementPatient.Persistence.EF.Repositories;

namespace Oponeo.ManagementPatient.Persistence.EF.Tests
{
    public class DoctorsRepositoryTests
    {
        private InMemoryDbContext inMemoryDbProvider = new InMemoryDbContext();

        [SetUp]
        public void Setup()
        {      
            var inMemoryContext = inMemoryDbProvider.GetMemoryContext();

            inMemoryContext.Doctors.Add(new Domain.Model.Doctor { FirstName = "John", LastName = "Doctor" });
            inMemoryContext.Doctors.Add(new Domain.Model.Doctor { FirstName = "Adam", LastName = "Doctor" });

            inMemoryContext.SaveChanges();
        }

        [Test]
        public void Should_Return_Doctor_If_Id_Is_Correct()
        {
            //Arrange
            var doctorRepository = new EFDoctorRepository(inMemoryDbProvider.GetMemoryContext());

            //Act
            var doctor = doctorRepository.GetById(1);

            //Assert
            Assert.IsNotNull(doctor);
            Assert.That(doctor.Id, Is.EqualTo(1));
            Assert.That(doctor.FirstName, Is.EqualTo("John"));
        }

        [Test]
        public void Should_Return_All_Doctors()
        {
            //Arrange
            var doctorRepository = new EFDoctorRepository(inMemoryDbProvider.GetMemoryContext());

            //Act
            var doctors = doctorRepository.GetAll();

            //Assert
            Assert.IsNotNull(doctors);
            Assert.That(doctors.Count(), Is.EqualTo(2));
        }
    }
}