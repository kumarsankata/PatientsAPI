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
        /// Gets all patients list
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

        /// <summary>
        /// Creates a new patient
        /// </summary>
        /// <param name="patientRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddPatient([FromBody]PatientRequestDto patientRequest)
        {
            try
            {
                if (patientRequest == null)
                    return BadRequest();

                if (!ModelState.IsValid)
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

        /// <summary>
        /// Updates a given patient
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="patientRequest"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult UpdatePatient(Guid Id, [FromBody] PatientRequestDto patientRequest)
        {
            var patient = _patientRepository.GetPatientById(Id);

            if (patient == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            patient.First_Name = patientRequest.First_Name;
            patient.Last_Name = patientRequest.Last_Name;
            patient.Gender = patientRequest.Gender;
            patient.Date_Of_Birth = patientRequest.Date_Of_Birth;
            patient.Email = patientRequest.Email;
            patient.Phone = patientRequest.Phone;
            patient.Is_Active = patientRequest.Is_Active;
            patient.Updated_At = DateTime.UtcNow;

            _patientRepository.UpdatePatient(Id, patient);

            return Ok(patient);
        }


        /// <summary>
        /// Gets all patients list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetPatientsPage")]
        public IActionResult GetPatientsList([FromQuery]int currentPage = 1, [FromQuery]int pageSize = 10)
        {
            try
            {
                var patientPageList = _patientRepository.GetPatientListPage(currentPage, pageSize);

                var patientResponsePageDto = new PatientResponsePageDto();
                patientResponsePageDto.TotalRecords = patientPageList.TotalRecordsCount;

                patientResponsePageDto.PatientsList = new List<PatientResponseDto>();
                foreach (var patient in patientPageList.Patients)
                {
                    patientResponsePageDto.PatientsList.Add(
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

                return Ok(patientResponsePageDto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Unexpected error happened. Please try after sometime");
            }
        }

    }
}