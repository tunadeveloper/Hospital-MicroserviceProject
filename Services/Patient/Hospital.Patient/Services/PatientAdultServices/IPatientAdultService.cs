using Hospital.Patient.Dtos.PatientAdultDtos;

namespace Hospital.Patient.Services.PatientAdultServices
{
    public interface IPatientAdultService
    {
        Task<List<ResultPatientAdultDto>> GetAllPatientAsync();
        Task CreatePatientAdultAsync(CreatePatientAdultDto createPatientAdultDto);
        Task UpdatePatientAdultAsync(UpdatePatientAdultDto updatePatientAdultDto);
        Task DeletePatientAdultAsync(string id);
        Task<GetByIdPatientAdultDto> GetByIdPatientAdultAsync(string id);
    }
}
