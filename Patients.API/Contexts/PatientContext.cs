using Microsoft.EntityFrameworkCore;
using Patients.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patients.API.Contexts
{
    public class PatientContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
    }
}
