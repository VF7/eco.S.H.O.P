namespace Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<Photo> Photos { get; set; }
        public List<Review> Reviews { get; set; }

        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }

    }
}
