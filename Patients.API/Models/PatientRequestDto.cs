using System;
using System.ComponentModel.DataAnnotations;

namespace Patients.API.Models
{
    public class PatientRequestDto
    {
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime Date_Of_Birth { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public bool Is_Active { get; set; }      
    }
}
