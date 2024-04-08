using System.ComponentModel.DataAnnotations.Schema;

namespace FiapSchool.Web.DTOs.Response
{
    public class TurmaResponseDto
    {
        public int curso_Id { get; set; }
        public string Turma { get; set; }
        public int Ano { get; set; }
    }
}
