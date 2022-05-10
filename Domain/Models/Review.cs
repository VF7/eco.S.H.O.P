namespace Domain.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public DateTime DateTimeReview { get; set; }

        public int Rate { get; set; }
        public User UserWhoReview { get; set; }
        public Product Product { get; set; }
    }
}
