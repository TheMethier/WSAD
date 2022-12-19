namespace New.Models
{
    public class OrderDetails
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public int GraId { get; set; }
        public int ilość { get; set; }
        public double Cena { get; set; }
        public Gra gra { get; set; }
        public Order Order { get; set; }
    }
}
