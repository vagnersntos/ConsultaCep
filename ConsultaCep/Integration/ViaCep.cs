using ConsultaCep.Integracao.Response;
using ConsultaCep.Integration.Interface;
using ConsultaCep.Integration.ViaCepIntegration;

namespace ConsultaCep.Integration
{
    public class ViaCep : IViaCep
    {
        private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;
        public ViaCep(IViaCepIntegrationRefit viaCepIntegrationRefit)
        {
            _viaCepIntegrationRefit = viaCepIntegrationRefit;
            
        }
        public async Task<ViaCepResponse> GetDataViaCep(string codePostal)
        {
            var viaDataResponse = new ViaCepResponse();

            var response = await _viaCepIntegrationRefit.GetDataViaCep(codePostal);

            if (response is not null && response.IsSuccessStatusCode)
            {
                viaDataResponse = response.Content;
            }

            return viaDataResponse;
        }
    }
}
