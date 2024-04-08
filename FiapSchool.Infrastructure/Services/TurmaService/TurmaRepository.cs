using FiapSchool.Infrastructure.Services.Base;
using FiapSchool.Models;
using System.Data;

namespace FiapSchool.Infrastructure.Services.TurmaService
{
    public class TurmaRepository : Repository<TurmaModel>, ITurmaRepository
    {
        public TurmaRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }

}
