
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

        Patient GetPatientById(Guid patientId);

        bool AddPatient(Patient patientRequest);

        bool UpdatePatient(Guid patientId, Patient patientRequest);
    }

}
