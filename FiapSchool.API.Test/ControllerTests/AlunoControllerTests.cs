using Moq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FiapSchool.Models;
using FiapSchool.API.Controllers;
using FiapSchool.Application.Mappings;
using FiapSchool.Application.DTOs.Response;
using FiapSchool.Infrastructure.Services.AlunoService;

namespace FiapSchool.API.Test.ControllerTests
{
    public class AlunoControllerTests
    {
        private readonly Mock<IAlunoRepository> _alunoRepositoryMock;
        private readonly IMapper _mapper;

        public AlunoControllerTests()
        {
            _alunoRepositoryMock = new Mock<IAlunoRepository>();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<EntitiesToDTOMappingProfile>());
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetAlunos_Returns_OkResult()
        {
            // Arrange
            _alunoRepositoryMock.Setup(repo => repo.GetAllAsync(It.IsAny<string>())).ReturnsAsync(new List<Aluno>());

            var controller = new AlunoController(_alunoRepositoryMock.Object, _mapper);

            // Act
            var result = await controller.GetAlunos();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<AlunoResponseDto>>(okResult.Value);
            // Verifica se a lista de alunos está vazia pois o teste tem função apenas de ver se nesse contexto o fluxo retornaria a lista de objetos.
            Assert.Empty(model);
        }

        [Fact]
        public async Task GetAlunoById_WithValidId_Returns_OkResult()
        {
            // Arrange
            var aluno = new Aluno { Id = 1, Nome = "João" };
            _alunoRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<string>(), 1)).ReturnsAsync(aluno);

            var controller = new AlunoController(_alunoRepositoryMock.Object, _mapper);

            // Act
            var result = await controller.GetAlunoById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<AlunoResponseDto>(okResult.Value);
            Assert.Equal(aluno.Id, model.Id);
        }

        [Fact]
        public async Task GetAlunoById_NotFoundTest()
        {
            // Arrange
            var aluno = new Aluno { Id = 1, Nome = "João" };
            _alunoRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync((Aluno)null);

            var controller = new AlunoController(_alunoRepositoryMock.Object, _mapper);

            // Act
            var result = await controller.GetAlunoById(2);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal("Aluno com ID 2 não encontrado", notFoundObjectResult.Value);
        }

    }
}
