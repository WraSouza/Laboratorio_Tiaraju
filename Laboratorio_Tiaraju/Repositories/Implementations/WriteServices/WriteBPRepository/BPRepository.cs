using Flurl;
using Flurl.Http;
using Laboratorio_Tiaraju.Helpers;
using Laboratorio_Tiaraju.Model.Entities;
using Laboratorio_Tiaraju.Repositories.Interfaces.IWriteServices.IWriteBPRepository;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Laboratorio_Tiaraju.Repositories.Implementations.WriteServices.WriteBPRepository
{
    public class BPRepository : IWBPRepository
    {
        public async Task<bool> InsertBusinessPartnerAsync(BusinessPartner businessPartner)
        {
            bool confirmaInsercao = false;
            string responseBody = string.Empty; 
          
            try
            {
                //var resultado = await Constants.urlParceiroNegocio                                               
                //                               .PostJsonAsync(businessPartner);

                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                string json = JsonConvert.SerializeObject(businessPartner);

                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                using (var client = new HttpClient(clientHandler))
                {
                    HttpResponseMessage response =  await client.PostAsync(Constants.urlParceiroNegocio, content);

                    if (response.StatusCode == HttpStatusCode.OK)
                        return response.IsSuccessStatusCode;

                    return false;
                }

                    


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return confirmaInsercao;
        }
    }
}
