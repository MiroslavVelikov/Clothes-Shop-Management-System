namespace Data.Entities
{
    /// <summary>
    /// class LastLog
    /// Has properies: Id ,Name, Role, Password and LogedIn
    /// int: Id
    /// string: Name, Role, Password
    /// bool: IsLogedIn
    /// </summary>
    public class LastLog
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsLogedIn { get; set; }
    }
}
