using ANCD.Application.Data;
using Dapper;
using System.Data;

namespace ANCD.Infra.Data.Repositories
{
    public class AbstractRepository
    {
        private readonly IDbContext _dbContext;

        public AbstractRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected IDbConnection GetConnection() => _dbContext.GetConnection();

        protected async Task<bool> ExecuteInTransactionAsync(string sql, object param = null)
        {
            var connection = GetConnection();

            using (var transaction = connection.BeginTransaction())
            {
                try
                {
                    var result = await connection.ExecuteAsync(sql, param, transaction);

                    transaction.Commit();
                    return result > 0;
                }
                catch (Exception)
                {
                    transaction.Rollback();

                    return false;
                }
            }
        }
    }
}
