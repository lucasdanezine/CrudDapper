using System.ComponentModel.DataAnnotations;


namespace BlazorWebFiapSchool.DTOs.Request
{
    public class TurmaRequestDto
    {
        [Required]
        [Range(1, 4, ErrorMessage = "O campo CursoId deve ser maior que zero.")]
        public int Curso_Id { get; set; }

        [Required(ErrorMessage = "O campo NomeTurma é obrigatório.")]
        public string Turma { get; set; }

        [Required]
        [Range(1, 4, ErrorMessage = "O campo Ano deve ser maior que zero.")]
        public int Ano { get; set; }
    }
}