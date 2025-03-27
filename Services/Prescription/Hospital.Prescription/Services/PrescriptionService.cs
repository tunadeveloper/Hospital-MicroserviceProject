using Hospital.Prescription.Dtos;
using Hospital.Prescription.Settings;
using System.Text.Json;

namespace Hospital.Prescription.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly RedisService _redisService;

        public PrescriptionService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeletePrescriptionAsync(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<PrescriptionTotalDto> GetPrescriptionTotalAsync(string userId)
        {
            var existPrescription = await _redisService.GetDb().StringGetAsync(userId);
            return JsonSerializer.Deserialize<PrescriptionTotalDto>(existPrescription);
        }

        public async Task SavePrescriptionAsync(PrescriptionTotalDto prescriptionTotal)
        {
            await _redisService.GetDb().StringSetAsync(prescriptionTotal.UserId, JsonSerializer.Serialize(prescriptionTotal));
        }
    }
}
