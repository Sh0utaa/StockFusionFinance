using AuthSystem.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthSystem.Models
{
    public class PortfolioModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? PortfolioId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string? Id { get; set; }
        
        [Required]
        public string Symbol { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Shares { get; set; }
        
        [Required]
        public double Cost { get; set; }

    }
}
