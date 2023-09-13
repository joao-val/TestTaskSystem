using SistemaDeTarefas_api_basica_.Integration.Interface;
using SistemaDeTarefas_api_basica_.Integration.Refit;
using SistemaDeTarefas_api_basica_.Integration.Response;

namespace SistemaDeTarefas_api_basica_.Integration
{
    public class ViaCepIntegration : IViaCepIntegration
    {
        private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;
        public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit)
        {
            _viaCepIntegrationRefit = viaCepIntegrationRefit;
        }
        public async Task<ViaCepResponse> GetDataViaCep(string cep)
        {
            var responseData = await _viaCepIntegrationRefit.GetDataViaCep(cep);
            
            if(responseData != null && responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }

            return null;
        }
    }
}
