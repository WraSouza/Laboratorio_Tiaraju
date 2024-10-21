namespace Laboratorio_Tiaraju.Model.Entities
{
    public class BPFiscalTaxIDCollection
    {
        public BPFiscalTaxIDCollection(string taxId0, string taxId1, string taxId4)
        {
            TaxId0 = taxId0;
            TaxId1 = taxId1;
            TaxId4 = taxId4;
        }

        public string TaxId0 { get; private set; } = string.Empty;
        public string TaxId1 { get; private set; } = string.Empty;
        public string TaxId2 { get; private set; } = string.Empty;
        public string TaxId3 { get; private set; } = string.Empty;
        public string TaxId4 { get; private set; } = string.Empty;
        public string BPCode { get; private set; } = string.Empty;
    }
}
