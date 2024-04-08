using BlazorWebFiapSchool.DTOs.Response;

using System.Net.Http.Json;

namespace BlazorWebFiapSchool.Services
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
            return await _httpClient.GetFromJsonAsync<ICollection<AlunoResponseDto>>("Alunos");
        }
    }
}
