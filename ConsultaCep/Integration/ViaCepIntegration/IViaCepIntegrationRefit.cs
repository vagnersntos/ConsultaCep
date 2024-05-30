using ConsultaCep.Integracao.Response;
using Refit;

namespace ConsultaCep.Integration.ViaCepIntegration
{
    public interface IViaCepIntegrationRefit
    {
        [Get("/ws/{codePostal}/json/")]
        Task<ApiResponse<ViaCepResponse>> GetDataViaCep(string codePostal);
    }
}
