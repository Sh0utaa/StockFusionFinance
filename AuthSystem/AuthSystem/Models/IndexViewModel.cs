using StockFusion_Finance.Models;

namespace AuthSystem.Models
{
    public class IndexViewModel
    {
        public TransactionsModel Transactions { get; set; } = new TransactionsModel();
        public List<TransactionsModel>? TransactionsList { get; set; }
        public PortfolioModel Portfolio { get; set; }
        public YahooApiModel.Root? StockData { get; set; }
    }
}
