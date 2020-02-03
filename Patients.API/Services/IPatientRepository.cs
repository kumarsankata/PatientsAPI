using Patients.API.Entities;
using Patients.API.HelperClasses;
using System;
using System.Collections.Generic;

namespace Patients.API.Services
{
    public interface IPatientRepository
    {
        List<Patient> GetPatientList();

        Patient GetPatientById(Guid patientId);

        bool AddPatient(Patient patientRequest);

        bool UpdatePatient(Guid patientId, Patient patientRequest);

        PaginationResult GetPatientListPage(int currentPage, int pageSize);
    }

}
