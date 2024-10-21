using Flurl;
using Flurl.Http;
using Laboratorio_Tiaraju.Helpers;
using Laboratorio_Tiaraju.Model.Entities;
using Laboratorio_Tiaraju.Repositories.Interfaces.IWriteServices.IWriteBPRepository;

namespace Laboratorio_Tiaraju.Repositories.Implementations.WriteServices.WriteBPRepository
{
    public class BPRepository : IWBPRepository
    {
        public async Task<bool> InsertBusinessPartnerAsync(BusinessPartner businessPartner)
        {
            bool confirmaInsercao = false;
          
            try
            {
                var resultado = await Constants.urlParceiroNegocio                                               
                                               .PostJsonAsync(businessPartner);
                               

                if(resultado.StatusCode == 200)
                    confirmaInsercao = true;

                return confirmaInsercao;


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return confirmaInsercao;
        }
    }
}
