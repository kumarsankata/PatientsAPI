using Microsoft.EntityFrameworkCore;
using Patients.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patients.API.Contexts
{
    public class PatientDBContext : DbContext
    {
        public PatientDBContext(DbContextOptions<PatientDBContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("Patient");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var patientList = new List<Patient>();
            patientList.Add(new Patient()
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

            patientList.Add(new Patient()
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

            modelBuilder.Entity<Patient>()
                .HasData(patientList);

            base.OnModelCreating(modelBuilder);
        }
    }
}
