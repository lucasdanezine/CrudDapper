using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Dapper;
using System.ComponentModel.DataAnnotations.Schema;
using FiapSchool.Services.Projeto.Infrastructure.Data;

namespace FiapSchool.Infrastructure.Services.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IDbConnection _dbConnection;

        public Repository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string tableName)
        {
            var sql = $"SELECT * FROM {tableName}";
            return await _dbConnection.QueryAsync<TEntity>(sql);
        }

        public async Task<TEntity> GetByIdAsync(string tableName, int id)
        {
            var sql = $"SELECT * FROM {tableName} WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<TEntity>(sql, new { Id = id });
        }

        public async Task<IEnumerable<TEntity>> CreateAsync(string tableName, TEntity entity)
        {
            var (columns, parameters) = GetColumnsAndParameters(entity);
            var sql = $"INSERT INTO {tableName} ({columns}) VALUES ({parameters})";
            var result = await _dbConnection.ExecuteAsync(sql, entity);
            //var testeResult = await GetByIdAsync(tableName,entity.)
            return await GetAllAsync(tableName);
        }

        public async Task<IEnumerable<TEntity>> UpdateAsync(string tableName, TEntity entity)
        {
            var (columns, parameters) = GetColumnsAndParameters(entity);
            var sql = $"UPDATE {tableName} SET {columns} WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, entity);
            return await GetAllAsync(tableName);
        }

        public async Task<IEnumerable<TEntity>> DeleteAsync(string tableName, int id)
        {
            var sql = $"DELETE FROM {tableName} WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
            return await GetAllAsync(tableName);
        }

        private (string Columns, string Parameters) GetColumnsAndParameters(TEntity entity)
        {
            var properties = entity.GetType().GetProperties()
                .Where(p => !Attribute.IsDefined(p, typeof(NotMappedAttribute))); // Exclui propriedades marcadas com [NotMapped]

            var columns = string.Join(", ", properties.Select(GetColumnName));
            var parameters = string.Join(", ", properties.Select(p => $"@{p.Name}"));

            return (columns, parameters);
        }

        private string GetColumnName(PropertyInfo property)
        {
            var columnAttribute = property.GetCustomAttribute<ColumnAttribute>();
            return columnAttribute != null ? columnAttribute.Name : property.Name;
        }
    }
}
