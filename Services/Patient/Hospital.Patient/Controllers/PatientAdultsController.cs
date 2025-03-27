using Hospital.Patient.Dtos.PatientAdultDtos;
using Hospital.Patient.Services.PatientAdultServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Patient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientAdultsController : ControllerBase
    {
        private readonly IPatientAdultService _patientAdultService;

        public PatientAdultsController(IPatientAdultService patientAdultService)
        {
            _patientAdultService = patientAdultService;
        }

        [HttpGet]
        public async Task<IActionResult> PatientAdultList()
        {
            var value = await _patientAdultService.GetAllPatientAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatientAdult(CreatePatientAdultDto createPatientAdultDto)
        {
            await _patientAdultService.CreatePatientAdultAsync(createPatientAdultDto);
            return Ok("Ekleme işlemi başarılı!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePatientAdult(UpdatePatientAdultDto updatePatientAdultDto)
        {
            await _patientAdultService.UpdatePatientAdultAsync(updatePatientAdultDto);
            return Ok("Güncelleme işlemi başarılı!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePatientAdult(string id)
        {
            await _patientAdultService.DeletePatientAdultAsync(id);
            return Ok("Silme işlemi başarılı!");
        }

        [HttpGet("GetPatientAdult")]
        public async Task<IActionResult> GetPatientAdult(string id)
        {
            var value = await _patientAdultService.GetByIdPatientAdultAsync(id);
            return Ok(value);
        }
    }
}
