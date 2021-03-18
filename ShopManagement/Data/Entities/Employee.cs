namespace Data.Entities
{
    /// <summary>
    /// class Employee
    /// Has properies: Id, Name, Role, Password, City and Salary
    /// string: Name, Role, Password, City
    /// int: Id
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
    }
}
