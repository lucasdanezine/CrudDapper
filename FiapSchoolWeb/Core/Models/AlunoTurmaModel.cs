using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FiapSchoolWeb.Core.Models
{
    public class AlunoTurmaModel
    {
        public int Aluno_Id { get; set; }
        public int Turma_Id { get; set; }
        public bool Situacao { get; set; }
    }
}