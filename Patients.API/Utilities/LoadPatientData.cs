using Patients.API.Contexts;
using Patients.API.Entities;
using System;
using System.Collections.Generic;

namespace Patients.API.Utilities
{
    public class LoadPatientData
    {
        /// <summary>
        /// Method to load initial data
        /// </summary>
        /// <param name="patientDBContext"></param>
        public static void LoadPatientContextData(PatientDBContext patientDBContext)
        {
            var patientList = new List<Patient>();
            patientDBContext.Patients.Add(
                new Patient()
                {
                    Id = Guid.NewGuid(),
                    First_Name = "Franks",
                    Last_Name = "Weiss",
                    Gender = "male",
                    Date_Of_Birth = Convert.ToDateTime("1997-11-08"),
                    Email = "franksweiss@portalis.com",
                    Phone = "02 94002366",
                    Is_Active = true,
                    Created_At = DateTime.UtcNow,
                    Updated_At = DateTime.UtcNow
                });

            patientDBContext.Patients.Add(
                new Patient()
                {
                    Id = Guid.NewGuid(),
                    First_Name = "Hull",
                    Last_Name = "Johnson",
                    Gender = "male",
                    Date_Of_Birth = Convert.ToDateTime("1970-06-26"),
                    Email = "franksweiss@portalis.com",
                    Phone = "02 94983574",
                    Is_Active = true,
                    Created_At = DateTime.UtcNow,
                    Updated_At = DateTime.UtcNow
                });

            patientDBContext.SaveChanges();
        }
    }
}
