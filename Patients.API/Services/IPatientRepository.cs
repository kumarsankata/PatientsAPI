
using Patients.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patients.API.Services
{
    public interface IPatientRepository
    {
        List<Patient> GetPatientList();

        bool AddPatient(Patient patientRequest);
    }

}
