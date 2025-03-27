using Hospital.Prescription.Dtos;
using Hospital.Prescription.LoginServices;
using Hospital.Prescription.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Prescription.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _service;
        private readonly ILoginService _loginService;

        public PrescriptionController(ILoginService loginService, IPrescriptionService service)
        {
            _loginService = loginService;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyPrescriptionDetail()
        {
            var user = User.Claims;
            var values = await _service.GetPrescriptionTotalAsync(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyPrescription(PrescriptionTotalDto prescriptionTotalDto)
        {
            prescriptionTotalDto.UserId = _loginService.GetUserId;
            await _service.SavePrescriptionAsync(prescriptionTotalDto);
            return Ok("Değişiklikler kaydedildi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMyPrescription()
        {
            await _service.DeletePrescriptionAsync(_loginService.GetUserId);
            return Ok("Değişiklikler kaydedildi");
        }
    }
}
