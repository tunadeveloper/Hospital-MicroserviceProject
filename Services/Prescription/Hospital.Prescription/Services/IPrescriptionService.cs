using Hospital.Prescription.Dtos;

namespace Hospital.Prescription.Services
{
    public interface IPrescriptionService
    {
        Task<PrescriptionTotalDto> GetPrescriptionTotalAsync(string userId);
        Task SavePrescriptionAsync(PrescriptionTotalDto prescriptionTotal);
        Task DeletePrescriptionAsync(string userId);
    }
}
