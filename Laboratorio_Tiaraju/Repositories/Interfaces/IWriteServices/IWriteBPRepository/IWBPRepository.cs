using Laboratorio_Tiaraju.Model.Entities;

namespace Laboratorio_Tiaraju.Repositories.Interfaces.IWriteServices.IWriteBPRepository
{
    public interface IWBPRepository
    {
        Task<bool> InsertBusinessPartnerAsync(BusinessPartner businessPartner);
    }
}
