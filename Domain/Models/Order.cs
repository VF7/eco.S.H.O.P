namespace Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public Address Address { get; set; }
        
        public List<Product> Product { get; set; }

        public User Buyer { get; set; }
        public DateTime SendData { get; set; }
        public DateTime DeliveryData { get; set; }
    }
}
