using AutoMapper;
using FiapSchool.Application.DTOs.Request;
using FiapSchool.Application.DTOs.Response;
using FiapSchool.Infrastructure.Services.AlunoTurmaService;
using Microsoft.AspNetCore.Mvc;

namespace FiapSchool.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoTurmaController : ControllerBase
    {
        private readonly IAlunoTurmaRepository _alunoTurmaRepository;
        private readonly IMapper _mapper;

        public AlunoTurmaController(IAlunoTurmaRepository alunoTurmaRepository, IMapper mapper)
        {
            _alunoTurmaRepository = alunoTurmaRepository;
            _mapper = mapper;
        }

        [HttpGet("turma/{turmaId}/alunos")]
        public IActionResult GetAlunosPorTurma(int turmaId)
        {
            try
            {
                var alunos = _alunoTurmaRepository.GetAlunosPorTurma(turmaId);
                return Ok(_mapper.Map<IEnumerable<AlunoResponseDto>>(alunos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter alunos da turma: {ex.Message}");
            }
        }

        [HttpPost("associacao")]
        public IActionResult CriarAssociacaoAlunoTurma([FromBody] AlunoTurmaRequestDto alunoTurmaRequestDto)
        {
            try
            {
                _alunoTurmaRepository.CriarAssociacaoAlunoTurma(alunoTurmaRequestDto.AlunoId, alunoTurmaRequestDto.TurmaId);
                return Ok("Associação aluno-turma criada com sucesso.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar associação aluno-turma: {ex.Message}");
            }
        }
    }
}
