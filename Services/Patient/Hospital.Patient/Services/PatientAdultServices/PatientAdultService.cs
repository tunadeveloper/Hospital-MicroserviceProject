using AutoMapper;
using Hospital.Patient.Dtos.PatientAdultDtos;
using Hospital.Patient.Entities;
using Hospital.Patient.Settings;
using MongoDB.Driver;

namespace Hospital.Patient.Services.PatientAdultServices
{
    public class PatientAdultService : IPatientAdultService
    {
        private readonly IMongoCollection<PatientAdult> _patientAdultCollection;
        private readonly IMapper _mapper;

        public PatientAdultService(IMapper mapper, IDatabaseSettings _databaseSetting)
        {
            var client = new MongoClient(_databaseSetting.ConnectionString);
            var databse = client.GetDatabase(_databaseSetting.DatabaseName);
            _patientAdultCollection = databse.GetCollection<PatientAdult>(_databaseSetting.PatientAdultCollectionName);
            _mapper = mapper;
        }

        public async Task CreatePatientAdultAsync(CreatePatientAdultDto createPatientAdultDto)
        {
            var values = _mapper.Map<PatientAdult>(createPatientAdultDto);
            await _patientAdultCollection.InsertOneAsync(values);
        }

        public async Task DeletePatientAdultAsync(string id)
        {
           await _patientAdultCollection.DeleteOneAsync(x => x.PatientAdultId == id);
        }

        public async Task<List<ResultPatientAdultDto>> GetAllPatientAsync()
        {
            var values = await _patientAdultCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultPatientAdultDto>>(values);
        }

        public async Task<GetByIdPatientAdultDto> GetByIdPatientAdultAsync(string id)
        {
            var value = await _patientAdultCollection.Find(x=>x.PatientAdultId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdPatientAdultDto>(value);
        }

        public async Task UpdatePatientAdultAsync(UpdatePatientAdultDto updatePatientAdultDto)
        {
            var value = _mapper.Map<PatientAdult>(updatePatientAdultDto);
            await _patientAdultCollection.ReplaceOneAsync(x => x.PatientAdultId == updatePatientAdultDto.PatientAdultId, value);
        }
    }
}
