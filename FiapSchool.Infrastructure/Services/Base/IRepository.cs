using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiapSchool.Services
{
    namespace Projeto.Infrastructure.Data
    {
        public interface IRepository<TEntity> where TEntity : class
        {
            Task<IEnumerable<TEntity>> GetAllAsync(string tableName);
            Task<TEntity> GetByIdAsync(string tableName, int id);
            Task<IEnumerable<TEntity>> CreateAsync(string tableName, TEntity entity);
            Task<IEnumerable<TEntity>> UpdateAsync(string tableName, TEntity entity);
            Task<IEnumerable<TEntity>> DeleteAsync(string tableName, int id);
        }
    }
}
