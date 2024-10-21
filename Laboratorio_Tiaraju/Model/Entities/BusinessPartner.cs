using System.Net;

namespace Laboratorio_Tiaraju.Model.Entities
{
    public class BusinessPartner
    {     
            public BusinessPartner(string cardName, string phone1, string emailAddress, List<BPFiscalTaxIDCollection>? bPFiscalTaxIDCollection, List<BPAddress>? bPAddresses)
            {
                CardName = cardName;
                CardType = "C";
                GroupCode = 109;
                Phone1 = phone1;
                EmailAddress = emailAddress;
                Series = 74;
                BPFiscalTaxIDCollection = bPFiscalTaxIDCollection;
                BPAddresses = bPAddresses;
            }


            public string CardName { get; set; } = string.Empty;
            public string CardType { get; set; } = string.Empty;
            public int GroupCode { get; set; }
            public string Phone1 { get; set; } = string.Empty;
            public string EmailAddress { get; set; } = string.Empty;
            public int Series { get; set; }
            public List<BPFiscalTaxIDCollection>? BPFiscalTaxIDCollection { get; set; }
            public List<BPAddress>? BPAddresses { get; set; }


        }

}
