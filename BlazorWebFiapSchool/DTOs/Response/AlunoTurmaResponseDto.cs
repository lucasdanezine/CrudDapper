namespace BlazorWebFiapSchool.DTOs.Response
{
    public class AlunoTurmaResponseDto
    {
        public int AlunoId { get; set; }
        public string AlunoNome { get; set; }
        public string AlunoUsuario { get; set; }
        public int TurmaId { get; set; }
        public string TurmaNome { get; set; }
        public int TurmaAno { get; set; }
    }
}
