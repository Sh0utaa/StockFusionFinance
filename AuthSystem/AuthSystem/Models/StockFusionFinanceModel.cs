using StockFusion_Finance.Models;

namespace AuthSystem.Models
{
    public class StockFusionFinanceModel
    {
        public TransactionsModel Transactions { get; set; } = new TransactionsModel();
        public List<TransactionsModel>? TransactionsList { get; set; }
        public PortfolioModel Portfolio { get; set; }
        public List<PortfolioModel> PortfolioList { get; set; }
        public Dictionary<string, object> Dictionary { get; set; }
        public YahooApiModel.Root? StockData { get; set; }
    }
}
