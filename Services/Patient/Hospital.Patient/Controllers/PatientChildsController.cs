using Hospital.Patient.Dtos.PatientChildDtos;
using Hospital.Patient.Services.PatientChildServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Patient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientChildsController : ControllerBase
    {
        private readonly IPatientChildService _patientChildService;

        public PatientChildsController(IPatientChildService patientChildService)
        {
            _patientChildService = patientChildService;
        }

        [HttpGet]
        public async Task<IActionResult> PatientChildList()
        {
            var value = await _patientChildService.GetAllPatientChildAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatientChild(CreatePatientChildDto createPatientChildDto)
        {
            await _patientChildService.CreatePatientChildAsync(createPatientChildDto);
            return Ok("Ekleme işlemi başarılı!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePatientChild(UpdatePatientChildDto updatePatientChildDto)
        {
            await _patientChildService.UpdatePatientChildAsync(updatePatientChildDto);
            return Ok("Gncelleme işlemi başarılı!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePatientChild(string id)
        {
            await _patientChildService.DeletePatientChildAsync(id);
            return Ok("Silme işlemi başarılı!");
        }

        [HttpGet("GetPatientChild")]
        public async Task<IActionResult> GetPatientChild(string id)
        {
            var value = await _patientChildService.GetByIdPatientChildAsync(id);
            return Ok(value);
        }
        
    }
}
