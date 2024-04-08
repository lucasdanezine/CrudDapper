using System.ComponentModel.DataAnnotations;

namespace FiapSchool.Application.DTOs.Request
{
    public class AlunoTurmaRequestDto
    {
        [Required(ErrorMessage = "O campo AlunoId é obrigatório.")]
        [Range(1, 4, ErrorMessage = "O campo AlunoId deve ser maior que zero.")]
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "O campo TurmaId é obrigatório.")]
        [Range(1, 4, ErrorMessage = "O campo TurmaId deve ser maior que zero.")]
        public int TurmaId { get; set; }
    }
}