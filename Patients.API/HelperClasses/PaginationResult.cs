using Patients.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patients.API.HelperClasses
{
    public class PaginationResult
    {
        public List<Patient> Patients { get; set; }
        public int TotalRecordsCount { get; set; }
    }
}
