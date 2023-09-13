using SistemaDeTarefas_api_basica_.Integration.Response;

namespace SistemaDeTarefas_api_basica_.Integration.Interface
{
    public interface IViaCepIntegration
    {
        Task<ViaCepResponse> GetDataViaCep(string cep);
    }
}
