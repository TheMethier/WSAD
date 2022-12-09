using System.ComponentModel.DataAnnotations;

namespace New.Models
{
    public class NowyKomentarz
    {
        public Guid Id { get; set; }
        [Required]
        public int GraId { get; set; }
        [Required(ErrorMessage = "Nie podano nazwy użytkownika")]
        public string Username { get; set; }
        [Required]
        public string Ocena { get; set; }
        [Required]
        public string Treść { get; set; }

    }
}
