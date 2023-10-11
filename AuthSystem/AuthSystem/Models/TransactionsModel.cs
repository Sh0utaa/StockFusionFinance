using AuthSystem.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthSystem.Models
{
    [Table("Transactions")]
    public class TransactionsModel
    {
        public int TransactionsId { get; set; }
        public string Symbol { get; set; }
        public double CurrentPrice { get; set; }
        public DateTime Time { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }


}
