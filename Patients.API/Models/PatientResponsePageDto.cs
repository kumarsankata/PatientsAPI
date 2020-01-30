using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patients.API.Models
{
    public class PatientResponsePageDto
    {
        public List<PatientResponseDto> PatientsList { get; set; }
        public int TotalRecords { get; set; }
    }
}
