using Refit;
using SistemaDeTarefas_api_basica_.Integration.Response;

namespace SistemaDeTarefas_api_basica_.Integration.Refit
{
    public interface IViaCepIntegrationRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> GetDataViaCep(string cep);
    }
}
