using Hospital.Patient.Dtos.PatientChildDtos;

namespace Hospital.Patient.Services.PatientChildServices
{
    public interface IPatientChildService
    {
        Task<List<ResultPatientChildDto>> GetAllPatientChildAsync();
        Task CreatePatientChildAsync(CreatePatientChildDto createPatientChildDto);
        Task UpdatePatientChildAsync(UpdatePatientChildDto updatePatientChildDto);
        Task DeletePatientChildAsync(string id);
        Task<GetByIdPatientChildDto> GetByIdPatientChildAsync(string id);
    }
}
