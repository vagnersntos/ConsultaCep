using ConsultaCep.Integracao.Response;
using Refit;

namespace ConsultaCep.Integration.Interface
{
    public interface IViaCep
    {
        Task<ViaCepResponse> GetDataViaCep(string codePostal);
    }
}
