using Patients.API.Entities;
using System.Collections.Generic;

namespace Patients.API.HelperClasses
{
    public class PaginationResult
    {
        public List<Patient> Patients { get; set; }
        public int TotalRecordsCount { get; set; }
    }
}
