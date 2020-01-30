using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Patients.API.Contexts;
using Patients.API.Entities;
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
                var patientList = _patientRepository.GetPatientList();
                var patientResponseDto = new List<PatientResponseDto>();

                foreach (var patient in patientList)
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
            catch (Exception)
            {
                return StatusCode(500, "Unexpected error happened. Please try after sometime");
            }
        }

        [HttpPost]
        public IActionResult AddPatient([FromBody]PatientRequestDto patientRequest)
        {
            try
            {
                if (patientRequest == null)
                    return BadRequest();
                var patient = new Patient()
                {
                    Id = Guid.NewGuid(),
                    First_Name = patientRequest.First_Name,
                    Last_Name = patientRequest.Last_Name,
                    Gender = patientRequest.Gender,
                    Date_Of_Birth = patientRequest.Date_Of_Birth,
                    Email = patientRequest.Email,
                    Phone = patientRequest.Phone,
                    Is_Active = patientRequest.Is_Active,
                    Created_At = DateTime.UtcNow,
                    Updated_At = DateTime.UtcNow
                };

                var isPatientAdded = _patientRepository.AddPatient(patient);
                if (isPatientAdded)
                    return Created("", patient);
                else
                    return StatusCode(500, "Unexpected error happened. Please try after sometime");
            }
            catch (Exception)
            {
                return StatusCode(500, "Unexpected error happened. Please try after sometime");
            }
        }


    }
}