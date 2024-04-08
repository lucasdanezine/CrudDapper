using FiapSchool.Models;


namespace FiapSchool.Infrastructure.Services.AlunoTurmaService
{
    public interface IAlunoTurmaRepository
    {
        IEnumerable<Aluno> GetAlunosPorTurma(int turmaId);
        void CriarAssociacaoAlunoTurma(int alunoId, int turmaId);
    }
}
