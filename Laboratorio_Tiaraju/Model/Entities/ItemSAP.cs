using Newtonsoft.Json;

namespace Laboratorio_Tiaraju.Model.Entities
{
    public class ItemSAP
    {
       // [JsonProperty("odata.metadata")]
        public string odatametadata { get; set; } = string.Empty;
        public List<Value>? value { get; set; }

       // [JsonProperty("odata.nextLink")]
        public string odatanextLink { get; set; } = string.Empty;
    }

    public class Value
    {
        public Value(string itemCode, string itemName, object barCode, double quantityOnStock)
        {
            ItemCode = itemCode;
            ItemName = itemName;
            BarCode = barCode;
            QuantityOnStock = quantityOnStock;
        }

        public string ItemCode { get; set; } = string.Empty;
        public string ItemName { get; set; } = string.Empty;
        public object BarCode { get; set; } = string.Empty;
        public double QuantityOnStock { get; set; }
    }
}
