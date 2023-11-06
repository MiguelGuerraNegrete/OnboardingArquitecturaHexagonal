using System.Text.Json.Serialization;

namespace AppTransaction.Domain
{
    public class Order
    {   
        public long OrderId { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int Units { get; set; }
        public Double ProductValue { get; set; }
        public Double Total { get; set; }
        public Boolean Canceled { get; set; }     
        [JsonIgnore]
        public ICollection<Product> Product { get; set; }
    }
}
