using ANCD.Application.Data;
using ANCD.Application.Data.Repositories;

namespace ANCD.Infra.Data
{
    public class DataManager : IDataManager
    {
        private readonly IDoctorRepository _doctorRepository;

        public IDoctorRepository DoctorRepository => _doctorRepository;

        public DataManager(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
    }
}
