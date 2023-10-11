using StockFusion_Finance.Models;

namespace AuthSystem.Models
{
    public class IndexViewModel
    {
        public List<TransactionsModel>? TransactionsList { get; set; }
        public YahooApiModel.Root? StockData { get; set; }
    }
}
