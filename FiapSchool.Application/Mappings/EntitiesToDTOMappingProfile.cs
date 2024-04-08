using AutoMapper;
using FiapSchool.Application.DTOs.Request;
using FiapSchool.Application.DTOs.Response;
using FiapSchool.Models;

namespace FiapSchool.Application.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile()
        {
            CreateMap<Aluno, AlunoRequestDto>().ReverseMap();
            CreateMap<Aluno, AlunoResponseDto>().ReverseMap();
            CreateMap<AlunoTurma, AlunoTurmaRequestDto>().ReverseMap();
            CreateMap<AlunoTurma, AlunoTurmaResponseDto>().ReverseMap();
            CreateMap<TurmaModel, TurmaRequestDto>().ReverseMap();
            CreateMap<TurmaModel, TurmaResponseDto>().ReverseMap();
        }
    }
}
