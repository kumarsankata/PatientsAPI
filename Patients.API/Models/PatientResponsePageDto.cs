using System.Collections.Generic;

namespace Patients.API.Models
{
    public class PatientResponsePageDto
    {
        public List<PatientResponseDto> PatientsList { get; set; }
        public int TotalRecords { get; set; }
    }
}
