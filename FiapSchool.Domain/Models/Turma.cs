using System.ComponentModel.DataAnnotations.Schema;

namespace FiapSchool.Models
{
    public class TurmaModel
    {
        [NotMapped]
        public int Id { get; set; }
        public int Curso_Id { get; set; }       
        public string Turma { get; set; }
        public int Ano { get; set; }
        public bool Situacao { get; set; }
    }
}