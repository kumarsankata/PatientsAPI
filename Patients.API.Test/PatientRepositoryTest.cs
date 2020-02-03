using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Patients.API.Contexts;
using Patients.API.Entities;
using Patients.API.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patients.API.Test
{
    [TestClass]
    public class PatientRepositoryTest
    {

        [TestMethod]
        public void TestGetPatientList()
        {
            var patientRepository = GetPatientRepository();
            var patientsList = patientRepository.GetPatientList();
            Assert.AreEqual(1, patientsList.Count);
        }



        private IPatientRepository GetPatientRepository()
        {

            var builder = new DbContextOptionsBuilder<PatientDBContext>();
            builder.UseInMemoryDatabase("Patient");

            var dbContextOptions = builder.Options;
            var patientDBContext = new PatientDBContext(dbContextOptions);
            patientDBContext.Database.EnsureDeleted();
            patientDBContext.Database.EnsureCreated();
            AddTestData(patientDBContext);

            var patientRepository = new PatientRepository(patientDBContext);
            return patientRepository;
        }

        private void AddTestData(PatientDBContext context)
        {
            context.Patients.Add(new Patient()
            {
                First_Name = "Kumar",
                Last_Name = "Sankata",
                Email = "Kumar.Sankata@pms.com",
                Created_At = DateTime.UtcNow,
                Date_Of_Birth = Convert.ToDateTime("2000-1-1"),
                Gender = "Male",
                Id = Guid.NewGuid(),
                Is_Active = true,
                Phone = "123456789"
            });
            context.SaveChanges();
        }
    }
}
