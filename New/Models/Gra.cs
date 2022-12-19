namespace New.Models
{
    public class Gra
    {
        public Gra(int id, string nazwa, string zdjęcie1, string zdjęcie2, string zdjęcie3, string kategoria, double cena, string opis, string specyfikacjat, string aktywacja)
        {
            this.Cena = cena;
            this.Opis = opis;   
            this.Id = id;
            this.Nazwa = nazwa;
            this.Zdjęcie1 = zdjęcie1;
            this.Zdjęcie2 = zdjęcie2;
            this.Zdjęcie3 = zdjęcie3;
            this.Kategoria = kategoria;
            this.Specyfikacjat = specyfikacjat;
            this.Aktywacja = aktywacja;
        }
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Zdjęcie1 { get; set; }
        public string Zdjęcie2 { get; set; }
        public string Zdjęcie3 { get; set; }
        public string Kategoria { get; set; }
        public double Cena { get; set; }
        public string Opis { get; set; }
        public string Specyfikacjat { get; set; }
        public string Aktywacja { get; set; }

        public ICollection<NowyKomentarz> NowyKomentarz { get; set; }
        public ICollection<Element_koszyka> Element_koszyka { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }


    }
}
