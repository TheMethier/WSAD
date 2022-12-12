namespace New.Models
{
    public class Element_koszyka
    {
        public Guid ElementId { get; set; }
        public string KoszykId { get; set; }
        public int Ilość { get; set; }
        public int GraId { get; set; }
        public Gra Gra { get; set; }
    }
}
