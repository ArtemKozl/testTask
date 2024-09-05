using testTask.Core.Models;
using testTask.DataAccess.Repositories;

namespace testTask.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private IDoctorsRepository _doctorsRepository;
        private IDistrictsRepository _districtsRepository;
        private IOfficesRepository _officesRepository;
        private ISpecializationsRepository _specializationsRepository;
        public DoctorService(IDoctorsRepository doctorsRepository, IDistrictsRepository districtsRepository,
            IOfficesRepository officesRepository, ISpecializationsRepository specializationsRepository)
        {
            _doctorsRepository = doctorsRepository;
            _districtsRepository = districtsRepository;
            _officesRepository = officesRepository;
            _specializationsRepository = specializationsRepository;
        }

        public async Task AddDoctor(string full_name, int district_number, int office_number, string specialization_name)
        {
            var district_number_create = await _districtsRepository.NumberExist(district_number);
            var office_number_create = await _officesRepository.NumberExist(office_number);
            var specialization_name_create = await _specializationsRepository.NameExist(specialization_name);

            Doctors doctor = Doctors.Create(0,full_name, office_number_create, specialization_name_create, district_number_create);

            await _doctorsRepository.Add(doctor);
        }

        public async Task EditingDoctor(int id, string full_name, int district_number, int office_number, string specialization_name)
        {
            var district_number_create = await _districtsRepository.NumberExist(district_number);
            var office_number_create = await _officesRepository.NumberExist(office_number);
            var specialization_name_create = await _specializationsRepository.NameExist(specialization_name);

            Doctors doctor = Doctors.Create(id, full_name, office_number_create, specialization_name_create, district_number_create);

            await _doctorsRepository.Editing(doctor);
        }

        public async Task DeleteDoctor(int id)
        {
            await _doctorsRepository.DeleteById(id);
        }

        public async Task<List<DoctorsForOutputList>> GetDoctorsList(string columnForSorting, int page)
        {
            List<Doctors> doctors = await _doctorsRepository.GetList(columnForSorting, page);
            List<DoctorsForOutputList> list = new List<DoctorsForOutputList>();

            foreach (var doctor in doctors)
            {
                DoctorsForOutputList doctorsForOutputList = new DoctorsForOutputList();

                doctorsForOutputList.Full_name = doctor.Full_name;
                doctorsForOutputList.District_number = await _districtsRepository.GetValueById(doctor.District_id);
                doctorsForOutputList.Office_number = await _officesRepository.GetValueById(doctor.Office_id);
                doctorsForOutputList.Specialization_name = await _specializationsRepository.GetValueById(doctor.Specialization_id);

                list.Add(doctorsForOutputList);
            }

            return list;
        }

        public async Task<object> GetDoctorBtId(int id)
        {
            return await _doctorsRepository.GetDoctorById(id);
        }
    }
}
