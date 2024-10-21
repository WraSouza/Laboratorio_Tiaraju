using Laboratorio_Tiaraju.Model.Entities;

namespace Laboratorio_Tiaraju.Repositories.Interfaces.IReadServices.IReadItemsServices
{
    public interface IRItemSAPServices
    {
        Task<ItemSAP> GetAllItemsAsync();
        Task<ItemSAP> GetItemByIdAsync(string itemCode);
    }
}
