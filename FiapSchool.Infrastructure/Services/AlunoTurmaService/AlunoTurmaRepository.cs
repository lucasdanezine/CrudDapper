using Dapper;
using FiapSchool.Application.DTOs.Response;
using FiapSchool.Models;
using System.Data;

namespace FiapSchool.Infrastructure.Services.AlunoTurmaService
{
    public class AlunoTurmaRepository : IAlunoTurmaRepository
    {
        private readonly IDbConnection _dbConnection;

        public AlunoTurmaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Aluno> GetAlunosPorTurma(int turmaId)
        {
            // Consulta SQL que retorna os dados dos alunos e suas turmas com base no Id da turma
            string sql = @"SELECT [Id]
                                 ,[Nome]
                                 ,[Usuario]
                                 ,[Senha]
                                  FROM Alunos
                                  WHERE Id in (SELECT[Aluno_Id]
                                            FROM Aluno_Turma
                                            WHERE Turma_Id = @TurmaId)";

            // Executar a consulta e mapear os resultados para objetos AlunoTurma
            return _dbConnection.Query<Aluno>(sql, new { TurmaId = turmaId });
        }

        public void CriarAssociacaoAlunoTurma(int alunoId, int turmaId)
        {
            // Verificar se os IDs de aluno e turma existem
            var alunoExists = _dbConnection.ExecuteScalar<bool>("SELECT 1 FROM Alunos WHERE Id = @AlunoId", new { AlunoId = alunoId });
            var turmaExists = _dbConnection.ExecuteScalar<bool>("SELECT 1 FROM Turmas WHERE Id = @TurmaId", new { TurmaId = turmaId });

            if (!alunoExists)
            {
                throw new ArgumentException("O ID do aluno fornecido não corresponde a um aluno existente.");
            }

            if (!turmaExists)
            {
                throw new ArgumentException("O ID da turma fornecido não corresponde a uma turma existente.");
            }

            // Criar associação entre aluno e turma
            var sql = "INSERT INTO Aluno_Turma (Aluno_Id, Turma_Id) VALUES (@AlunoId, @TurmaId)";
            _dbConnection.Execute(sql, new { AlunoId = alunoId, TurmaId = turmaId });
        }
    }
}