namespace Data.Entities
{
    /// <summary>
    /// class Clothe
    /// Has properies: Id, Type, Name, Quantity, Price, Sex, City and Delivered
    /// string: Type, Name, Sex, City
    /// int: Id, Qunatity
    /// decimal: Price
    /// bool: Delivered
    /// </summary>
    public class Clothe
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Sex { get; set; }
        public string City { get; set; }
        public bool Delivered { get; set; }
    }
}
