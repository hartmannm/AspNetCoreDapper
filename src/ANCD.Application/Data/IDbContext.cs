using System.Data;

namespace ANCD.Application.Data
{
    public interface IDbContext
    {
        IDbConnection GetConnection();
    }
}
