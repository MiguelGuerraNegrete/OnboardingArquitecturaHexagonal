using System.Text.Json.Serialization;

namespace AppTransaction.Domain
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public double AvailableBalance { get; set; }
        [JsonIgnore]
        public  ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
