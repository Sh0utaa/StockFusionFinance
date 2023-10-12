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
        public string Symbol { get; set; }
        public double CurrentPrice { get; set; }
        public DateTime Time { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public string Action { get; set; }
    }
}
