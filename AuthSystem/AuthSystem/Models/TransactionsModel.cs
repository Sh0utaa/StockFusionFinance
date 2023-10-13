using AuthSystem.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthSystem.Models
{
    [Table("Transactions")]
    public class TransactionsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? TransactionsId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Required] // Ensure Symbol is not null
        public string Symbol { get; set; }

        [Required]
        public double CurrentPrice { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required] // Ensure Quantity is not null
        public int Quantity { get; set; }

        [Required]
        public double Cost { get; set; }

        [Required] // Ensure Action is not null
        public string Action { get; set; }
    }
}
