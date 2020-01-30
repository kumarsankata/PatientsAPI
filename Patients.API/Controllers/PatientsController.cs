using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patients.API.Contexts;
using Patients.API.Models;
using Patients.API.Services;

namespace Patients.API.Controllers
{
    [Route("api/v1/patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {

        IPatientRepository _patientRepository;

        public PatientsController(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetPatientsList()
        {
            try
            {
                var patientRepoList = _patientRepository.GetPatientList();
                var patientResponseDto = new List<PatientResponseDto>();             

                foreach (var patient in patientRepoList)
                {
                    patientResponseDto.Add(
                        new PatientResponseDto
                        {
                            Id = patient.Id,
                            First_Name = patient.First_Name,
                            Last_Name = patient.Last_Name,
                            Gender = patient.Gender,
                            Date_Of_Birth = patient.Date_Of_Birth,
                            Email = patient.Email,
                            Phone = patient.Phone,
                            Is_Active = patient.Is_Active,
                            Created_At = patient.Created_At,
                            Updated_At = patient.Updated_At
                        });
                }

                return Ok(patientResponseDto);
            }
            catch(Exception)
            {
                return StatusCode(500, "Unexpected error happened. Please try after sometime");
            }
        }




    }
}