using Flurl.Http;
using Laboratorio_Tiaraju.Helpers;
using Laboratorio_Tiaraju.Model.Entities;
using Laboratorio_Tiaraju.Repositories.Interfaces.IReadServices.IReadItemsServices;

namespace Laboratorio_Tiaraju.Repositories.Implementations.ReadServices.ReadItemsSAPServices
{
    public class RItemsSAPServices : IRItemSAPServices
    {
        public async Task<ItemSAP> GetAllItemsAsync()
        {
            try
            {
                return await Constants.urlAPI
                                .GetJsonAsync<ItemSAP>();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public Task<ItemSAP> GetItemByIdAsync(string itemCode)
        {
            throw new NotImplementedException();
        }
    }
}
