using System.ComponentModel.DataAnnotations.Schema;

namespace FiapSchool.Models
{
    public class Aluno
    {
        [NotMapped]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool Situacao { get; set; }
    }
}
