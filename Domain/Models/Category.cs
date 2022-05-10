namespace Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public Category SubCategory { get; set; }
    }
}
