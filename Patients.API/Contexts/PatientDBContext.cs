using Microsoft.EntityFrameworkCore;
using Patients.API.Entities;

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
    }
}
