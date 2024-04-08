using System.ComponentModel.DataAnnotations;

namespace FiapSchool.Web.DTOs.Request
{
    public class AlunoRequestDto
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "O campo Usuario é obrigatório.")]
        public string usuario { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string senha { get; set; }
    }
}