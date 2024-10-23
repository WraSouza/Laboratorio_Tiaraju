using Flunt.Validations;
using InputKit.Shared.Validations;
using Laboratorio_Tiaraju.Model.Entities;

namespace Laboratorio_Tiaraju.Validators
{
    public class BusinessPartnerContract : Contract<BusinessPartner>
    {
        public BusinessPartnerContract(BusinessPartner businessPartner)
        {
            Requires()
               .IsNotNullOrEmpty(businessPartner.CardName, nameof(businessPartner.CardName), "Nome do Cliente Deve Ser Preenchido");

            Requires()
                .IsGreaterOrEqualsThan(businessPartner.BPFiscalTaxIDCollection[0].TaxId4, 11, businessPartner.BPFiscalTaxIDCollection[0].TaxId4, "CPF Deve Possuir 11 Dígitos");

            Requires()
                .IsGreaterOrEqualsThan(businessPartner.BPAddresses[0].ZipCode, 8, businessPartner.BPAddresses[0].ZipCode, "O CEP Deve Possuir 8 Dígitos");
               
        }
    }
}
