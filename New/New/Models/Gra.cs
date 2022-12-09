namespace New.Models
{
    public class Gra
    {
        public Gra(int id, string nazwa, string z1, string z2, string z3, string kategoria, double cena, string opis)
        {
            this.Cena = cena;
            this.Opis = opis;   
            this.Id = id;
            this.Nazwa = nazwa;
            this.Zdjęcie1 = z1;
            this.Zdjęcie2 = z2;
            this.Zdjęcie3 = z3;
            this.Kategoria = kategoria;
        }
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Zdjęcie1 { get; set; }
        public string Zdjęcie2 { get; set; }
        public string Zdjęcie3 { get; set; }
        public string Kategoria { get; set; }
        public double Cena { get; set; }
        public string Opis { get; set; }
        public string SpecyfikacjaT { get; set; }
        public string Aktywacja { get; set; }
    }
}
