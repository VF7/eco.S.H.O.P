namespace Domain.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public List<Product> Product { get; set; }
        public Address AddressFrom { get; set; }
        public Address AddressTo { get; set; }
        public DateTime SendData { get; set; }
        public DateTime DeliveryData { get; set; }
    }
}
