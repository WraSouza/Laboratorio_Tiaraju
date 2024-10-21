using Flunt.Validations;
using Laboratorio_Tiaraju.Model.Entities;

namespace Laboratorio_Tiaraju.Validators
{
    public class BusinessPartnerContract : Contract<BusinessPartner>
    {
        public BusinessPartnerContract(BusinessPartner businessPartner)
        {
            Requires()
               .IsNotNullOrEmpty(businessPartner.CardName, nameof(businessPartner.CardName), "Nome do Cliente Deve Ser Preenchido");
               
        }
    }
}
