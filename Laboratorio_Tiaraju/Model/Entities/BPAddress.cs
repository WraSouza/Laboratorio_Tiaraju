namespace Laboratorio_Tiaraju.Model.Entities
{
    public class BPAddress
    {
        public BPAddress(string street, string block, string zipCode, string city, string state, string streetNo)
        {
            AddressName = "COBRANÇA";
            Street = street;
            Block = block;
            ZipCode = zipCode;
            City = city;
            State = state;
            StreetNo = streetNo;
        }
        
        public string AddressName { get; private set; } = string.Empty;
        public string Street { get; private set; } = string.Empty;
        public string Block { get; private set; } = string.Empty;
        public string ZipCode { get; private set; } = string.Empty;
        public string City { get; private set; } = string.Empty;
        public string State { get; private set; } = string.Empty;
        public string StreetNo { get; private set; } = string.Empty;
    }
}
