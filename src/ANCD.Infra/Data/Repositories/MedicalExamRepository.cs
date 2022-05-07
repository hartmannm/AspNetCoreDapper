using ANCD.Application.Data;
using ANCD.Application.Data.Repositories;
using ANCD.Domain.Entities;

namespace ANCD.Infra.Data.Repositories
{
    public class MedicalExamRepository : AbstractRepository, IMedicalExamRepository
    {
        public MedicalExamRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> Schedule(MedicalExam exam)
        {
            throw new NotImplementedException();
        }
    }
}
