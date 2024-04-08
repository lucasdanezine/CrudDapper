using AutoMapper;
using FiapSchool.Application.DTOs.Request;
using FiapSchool.Application.DTOs.Response;
using FiapSchool.Infrastructure.Services.AlunoService;
using FiapSchool.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiapSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;
        private const string TableName = "Alunos";
        private readonly IMapper _mapper;
        public AlunoController(IAlunoRepository alunoRepository, IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlunos()
        {
            try
            {
                var alunos = await _alunoRepository.GetAllAsync(TableName);
                var resultMapper = _mapper.Map<ICollection<AlunoResponseDto>>(alunos);
                return Ok(resultMapper);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar alunos: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlunoById(int id)
        {
            try
            {
                var aluno = await _alunoRepository.GetByIdAsync(TableName,id);
                if (aluno == null)
                    return NotFound($"Aluno com ID {id} não encontrado");

                return Ok(_mapper.Map<AlunoResponseDto>(aluno));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao buscar aluno: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAluno([FromBody]AlunoRequestDto alunoDto)
        {
            try
            {
                var alunos = await _alunoRepository.CreateAsync(TableName,_mapper.Map<Aluno>(alunoDto));
                return Ok(_mapper.Map<ICollection<AlunoResponseDto>>(alunos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao criar aluno: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAluno(int id, [FromBody]AlunoRequestDto alunoDto)
        {
            try
            {
                var alunos = await _alunoRepository.UpdateAsync(TableName, _mapper.Map<Aluno>(alunoDto));
                return Ok(_mapper.Map<IEnumerable<AlunoResponseDto>>(alunos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao atualizar aluno: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAluno(int id)
        {
            try
            {
                var alunos = await _alunoRepository.DeleteAsync(TableName,id);
                return Ok(_mapper.Map<IEnumerable<AlunoResponseDto>>(alunos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao excluir aluno: {ex.Message}");
            }
        }

    }
}
