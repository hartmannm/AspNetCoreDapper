using ANCD.Application.Data.Repositories;

namespace ANCD.Application.Data
{
    public interface IDataManager
    {
        IDoctorRepository DoctorRepository { get; }

        IPatientRepository PatientRepository { get; }

        IMedicalExamRepository MedicalExamRepository { get; }
    }
}
