using AutoMapper;
using FiapSchool.Application.DTOs.Request;
using FiapSchool.Application.DTOs.Response;
using FiapSchool.Infrastructure.Services.TurmaService;
using FiapSchool.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiapSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepository _turmaRepository;
        private const string TableName = "Turmas";
        private readonly IMapper _mapper;

        public TurmaController(ITurmaRepository turmaRepository, IMapper mapper)
        {
            _turmaRepository = turmaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTurmas()
        {
            try
            {
                var turmas = await _turmaRepository.GetAllAsync(TableName);
                return Ok(_mapper.Map<IEnumerable<TurmaResponseDto>>(turmas));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao buscar turmas: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTurmaById(int id)
        {
            try
            {
                var turma = await _turmaRepository.GetByIdAsync(TableName, id);
                if (turma == null)
                    return NotFound($"Turma com ID {id} não encontrada");

                return Ok(_mapper.Map<TurmaResponseDto>(turma));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao buscar turma: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTurma([FromBody]TurmaRequestDto turmaDto)
        {
            try
            {
                var mapper = _mapper.Map<TurmaModel>(turmaDto);
                var turmas = await _turmaRepository.CreateAsync(TableName, _mapper.Map<TurmaModel>(turmaDto));
                return Ok(_mapper.Map<IEnumerable<TurmaResponseDto>>(turmas));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao criar turma: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTurma(int id, [FromBody]TurmaRequestDto turmaDto)
        {
            try
            {
                var turmas = await _turmaRepository.UpdateAsync(TableName, _mapper.Map<TurmaModel>(turmaDto));
                return Ok(_mapper.Map<IEnumerable<TurmaResponseDto>>(turmas));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao atualizar turma: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurma(int id)
        {
            try
            {
                var turmas = await _turmaRepository.DeleteAsync(TableName, id);
                return Ok(_mapper.Map<IEnumerable<TurmaResponseDto>>(turmas));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao excluir turma: {ex.Message}");
            }
        }
    }
}
