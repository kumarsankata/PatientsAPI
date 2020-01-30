﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Patients.API.Contexts;
using Patients.API.Entities;

namespace Patients.API.Services
{
    public class PatientRepository : IPatientRepository
    {
        PatientDBContext _dbContext;

        public PatientRepository(PatientDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        public List<Patient> GetPatientList()
        {
            return _dbContext.Patients.OrderBy(p => p.First_Name).ToList();
        }


    }
}
