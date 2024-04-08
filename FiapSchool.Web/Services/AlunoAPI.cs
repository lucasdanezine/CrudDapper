using FiapSchool.Web.DTOs.Response;
using System.Net.Http.Json;

namespace FiapSchool.Web.Services
{
    public class AlunoAPI
    {
        private readonly HttpClient _httpClient;
        public AlunoAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<AlunoResponseDto>?> GetAlunosAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<AlunoResponseDto>>("Aluno/10");
        }
    }
}