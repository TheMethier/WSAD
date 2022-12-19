using System.ComponentModel.DataAnnotations;

namespace New.Models
{
    public class Komentarz
    {
        public int Id { get; set; }
        
        public int DrinkId { get; set; }
        public string Username { get; set; }
       
        public string Ocena { get; set; }
    
        public string Treść { get; set; }

    }
}
