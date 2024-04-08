using FiapSchoolWeb.Core.Validations;
using System.ComponentModel.DataAnnotations;

namespace FiapSchoolWeb.Core.Models
{
    public class TurmaModel
    {
        [Key]
        public int Id { get; set; }
        public int Curso_Id { get; set; }

        [UniqueTurma(ErrorMessage = "Já existe uma turma com o mesmo nome.")]
        public string Turma { get; set; }

        [FutureYear(ErrorMessage = "O ano da turma não pode ser anterior ao ano atual.")]
        public int Ano { get; set; }
        public bool Situacao { get; set; }
    }
}