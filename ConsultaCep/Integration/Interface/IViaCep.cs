using ConsultaCep.Integracao.Response;

namespace ConsultaCep.Integration.Interface
{
    public interface IViaCep
    {
        Task<ViaCepResponse> GetDataViaCep(string codePostal);
    }
}
