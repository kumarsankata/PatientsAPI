using System;
using System.Collections.Generic;
using System.Linq;
using Patients.API.Contexts;
using Patients.API.Entities;
using Patients.API.HelperClasses;

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

        public bool AddPatient(Patient patientRequest)
        {
            _dbContext.Patients.Add(patientRequest);
            if (_dbContext.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public Patient GetPatientById(Guid patientId)
        {
            var patient = _dbContext.Patients.Where(p => p.Id == patientId).FirstOrDefault();
            return patient;
        }

        public bool UpdatePatient(Guid patientId, Patient patientRequest)
        {
            var patient = GetPatientById(patientId);
            patient = patientRequest;

            if (_dbContext.SaveChanges() > 0)
                return true;
            else
                return false;
        }

        public PaginationResult GetPatientListPage(int currentPage, int pageSize)
        {
            var paginationResult = new PaginationResult();
            paginationResult.Patients = _dbContext.Patients
                .OrderBy(p => p.First_Name)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            paginationResult.TotalRecordsCount = _dbContext.Patients.Count();

            return paginationResult;
        }
    }
}
