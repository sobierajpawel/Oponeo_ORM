// See https://aka.ms/new-console-template for more information
using Oponeo.ManagementPatient.Application;
using Oponeo.ManagementPatient.Persistence.Dapper.Repositories;
using Oponeo.ManagementPatient.Persistence.EF.DatabaseContext;
using Oponeo.ManagementPatient.Persistence.EF.Repositories;
using Oponeo.ManagementPatient.Persistence.EF.Seeding;
using Oponeo.ManagementPatient.Persistence.NHibernate.Repositories;

Console.WriteLine("Hello Onion architecture with differents ORMs!");


NHibernatePatientRepository nHibernatePatientRepository = new NHibernatePatientRepository();
nHibernatePatientRepository.Add(new Oponeo.ManagementPatient.Domain.Model.Patient
{
    FirstName = "Patient",
    LastName = "NHibernate"
});

NHibernateDoctorRepository nHibernateDoctorRepository = new NHibernateDoctorRepository();
nHibernateDoctorRepository.Add(new Oponeo.ManagementPatient.Domain.Model.Doctor
{
    FirstName = "Doctor",
    LastName = "NHibernate"
});

VisitCalendarService visitCalendarService = new(doctorRepository: new NHibernateDoctorRepository(),
    patientRepository: new NHibernatePatientRepository(), visitRepository: new NHibernateVisitRepository());
visitCalendarService.MakeVisit(1, 1, DateTime.Now);

//using (var context = new PatientDbContext())
//{
//    new CustomSeedData(context).SeedDoctors();
//}

//Console.WriteLine(Environment.NewLine);
//Console.Write("EF - add visit");
//using (var context = new PatientDbContext())
//{
//    VisitCalendarService visitCalendarServiceEF = new(doctorRepository: new EFDoctorRepository(context),
//        patientRepository: new EFPatientRepository(context),
//        visitRepository: new EFVisitsRepository(context));
//    visitCalendarServiceEF.MakeVisit(1, 1, DateTime.Now);
//}

//Console.WriteLine(Environment.NewLine);
//Console.Write("Dapper - add visit");

//VisitCalendarService visitCalendarService = new(doctorRepository: new DapperDoctorRepository(),
//    patientRepository: new DapperPatientRepository(), visitRepository: new DapperVisitRepository());
//visitCalendarService.MakeVisit(1, 1, DateTime.Now);

//Console.WriteLine(Environment.NewLine);
//Console.WriteLine("EF - get visits");

////EF
//using (var context = new PatientDbContext())
//{
//    var EFvisitRepository = new EFVisitsRepository(context);
//    foreach (var visit in EFvisitRepository.GetAll())
//    {
//        Console.WriteLine($"Wizyta {visit.VisitDateTime}, Pacjent: {visit.Patient.FirstName} {visit.Patient.LastName}, " +
//            $"Lekarz: {visit.Doctor.FirstName} {visit.Doctor.LastName}");
//    }
//}

//Console.WriteLine(Environment.NewLine);
//Console.WriteLine("Dapper - get visits");

////Dapper
//var visitRepository = new DapperVisitRepository();
//foreach (var visit in visitRepository.GetAll())
//{
//    Console.WriteLine($"Wizyta {visit.VisitDateTime}, Pacjent: {visit.Patient.FirstName} {visit.Patient.LastName}, " +
//        $"Lekarz: {visit.Doctor.FirstName} {visit.Doctor.LastName}");
//}