namespace Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public double Salary { get; set; }
        public DateTime DateStartWork { get; set; }
    }
}
