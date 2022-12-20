namespace New.Models
{
    public class Element_koszyka
    {
        public int ElementId { get; set; }
        public int GraId { get; set; }
        public Gra Gra { get; set; }
        public int Ilość { get; set; }
        public double Razem { get; set; }
    }
}
