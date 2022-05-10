namespace Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<string> Photos { get; set; }
        public List<Review> Reviews { get; set; }

        public Employee Employee { get; set; }

    }
}
