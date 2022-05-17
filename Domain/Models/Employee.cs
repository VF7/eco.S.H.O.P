namespace Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public UserInfo UserInfo { get; set; }
        public double Salary { get; set; }
        public DateTime DateStartWork { get; set; }
    }
}
