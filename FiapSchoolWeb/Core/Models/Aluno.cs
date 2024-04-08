using FiapSchoolWeb.Core.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapSchoolWeb.Core.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MinLength(8, ErrorMessage = "A senha deve conter pelo menos 8 caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",ErrorMessage = "A senha deve conter pelo menos uma letra minúscula, uma letra maiúscula, um dígito e um caractere especial.")]
        public string Senha { get; set; }
        public bool Situacao { get; set; }
    }
}
