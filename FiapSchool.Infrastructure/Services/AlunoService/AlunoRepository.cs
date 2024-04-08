using FiapSchool.Models;
using FiapSchool.Services.Projeto.Infrastructure.Data;
using Dapper;
using System.Data;
using FiapSchool.Infrastructure.Services.Base;

namespace FiapSchool.Infrastructure.Services.AlunoService
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(IDbConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
