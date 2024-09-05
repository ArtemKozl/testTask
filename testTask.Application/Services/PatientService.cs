using testTask.Core.Models;
using testTask.DataAccess.Repositories;

namespace testTask.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatiensRepository _patientRepository;
        private readonly IDistrictsRepository _districtsRepository;

        public PatientService(IPatiensRepository patientRepository, IDistrictsRepository districtsRepository)
        {
            _patientRepository = patientRepository;
            _districtsRepository = districtsRepository;
        }
        public async Task AddPatient(string second_name, string first_name, string middle_name, string address,
            DateOnly date_of_bith, char gender, int district_number)
        {
            var district_number_create = await _districtsRepository.NumberExist(district_number);

            Patiens doctor = Patiens.Create(0, second_name, first_name, middle_name, address,
                date_of_bith, gender, district_number_create);

            await _patientRepository.Add(doctor);
        }

        public async Task EditingPatient(int id, string second_name, string first_name, string middle_name, string address
            , DateOnly date_of_bith, char gender, int district_number)
        {
            var district_number_create = await _districtsRepository.NumberExist(district_number);


            Patiens doctor = Patiens.Create(id, second_name, first_name, middle_name, address,
                date_of_bith, gender, district_number_create);

            await _patientRepository.Editing(doctor);
        }

        public async Task DeletePatienr(int id)
        {
            await _patientRepository.DeleteById(id);
        }

        public async Task<List<PatiensForOutputList>> GetPatientsList(string columnForSorting, int page)
        {
            List<Patiens> patients = await _patientRepository.GetList(columnForSorting, page);
            List<PatiensForOutputList> list = new List<PatiensForOutputList>();

            foreach (var patient in patients)
            {
                PatiensForOutputList patientForOutputList = new PatiensForOutputList();

                patientForOutputList.First_name = patient.First_name;
                patientForOutputList.Second_name = patient.Second_name;
                patientForOutputList.Middle_name = patient.Middle_name;
                patientForOutputList.Address = patient.Address;
                patientForOutputList.Date_of_bith = patient.Date_of_bith;
                patientForOutputList.Gender = patient.Gender;
                patientForOutputList.District_number = await _districtsRepository.GetValueById(patient.District_id);

                list.Add(patientForOutputList);
            }

            return list;
        }

        public async Task<object> GetPatientById(int id)
        {
            return await _patientRepository.GetPatientsById(id);
        }
    }
}
