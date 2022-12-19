using System.ComponentModel.DataAnnotations;

namespace New.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        [Required]
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [CreditCard]
        public string CreditCard { get; set; }
        public DateTime CreatedDate { get; set; }
        public double Razem { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }

    }
}
