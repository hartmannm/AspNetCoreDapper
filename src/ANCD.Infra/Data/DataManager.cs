using ANCD.Application.Data;
using ANCD.Application.Data.Repositories;

namespace ANCD.Infra.Data
{
    public class DataManager : IDataManager
    {
        private readonly IDoctorRepository _doctorRepository;

        private readonly IPatientRepository _patientRepository;

        private readonly IMedicalExamRepository _medicalExamRepository;

        public IDoctorRepository DoctorRepository => _doctorRepository;

        public IPatientRepository PatientRepository => _patientRepository;

        public IMedicalExamRepository MedicalExamRepository => _medicalExamRepository;

        public DataManager(IDoctorRepository doctorRepository, IPatientRepository patientRepository, IMedicalExamRepository medicalExamRepository)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _medicalExamRepository = medicalExamRepository;
        }
    }
}
