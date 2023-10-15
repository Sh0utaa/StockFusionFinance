using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StockFusion_Finance.Models
{
    public class YahooApiModel
    {
        public class CompanyOfficer
        {
            [JsonProperty("age")]
            public int? Age { get; set; }

            [JsonProperty("exercisedValue")]
            public int? ExercisedValue { get; set; }

            [JsonProperty("fiscalYear")]
            public int? FiscalYear { get; set; }

            [JsonProperty("maxAge")]
            public int? MaxAge { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("totalPay")]
            public int? TotalPay { get; set; }

            [JsonProperty("unexercisedValue")]
            public int? UnexercisedValue { get; set; }

            [JsonProperty("yearBorn")]
            public int? YearBorn { get; set; }
        }

        public class Data
        {
            [JsonProperty("52WeekChange")]
            public double? _52WeekChange { get; set; }

            [JsonProperty("SandP52WeekChange")]
            public double? SandP52WeekChange { get; set; }

            [JsonProperty("address1")]
            public string Address1 { get; set; }

            [JsonProperty("ask")]
            public double? Ask { get; set; }

            [JsonProperty("askSize")]
            public int? AskSize { get; set; }

            [JsonProperty("auditRisk")]
            public int? AuditRisk { get; set; }

            [JsonProperty("averageDailyVolume10Day")]
            public int? AverageDailyVolume10Day { get; set; }

            [JsonProperty("averageVolume")]
            public int? AverageVolume { get; set; }

            [JsonProperty("averageVolume10days")]
            public int? AverageVolume10days { get; set; }

            [JsonProperty("beta")]
            public double? Beta { get; set; }

            [JsonProperty("bid")]
            public double? Bid { get; set; }

            [JsonProperty("bidSize")]
            public int? BidSize { get; set; }

            [JsonProperty("boardRisk")]
            public int? BoardRisk { get; set; }

            [JsonProperty("bookValue")]
            public double? BookValue { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("compensationAsOfEpochDate")]
            public int? CompensationAsOfEpochDate { get; set; }

            [JsonProperty("compensationRisk")]
            public int? CompensationRisk { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("currentPrice")]
            public double? CurrentPrice { get; set; }

            [JsonProperty("currentRatio")]
            public double? CurrentRatio { get; set; }

            [JsonProperty("dateShortInterest")]
            public int? DateShortInterest { get; set; }

            [JsonProperty("dayHigh")]
            public double? DayHigh { get; set; }

            [JsonProperty("dayLow")]
            public double? DayLow { get; set; }

            [JsonProperty("debtToEquity")]
            public double? DebtToEquity { get; set; }

            [JsonProperty("dividendRate")]
            public double? DividendRate { get; set; }

            [JsonProperty("dividendYield")]
            public double? DividendYield { get; set; }

            [JsonProperty("earningsGrowth")]
            public double? EarningsGrowth { get; set; }

            [JsonProperty("earningsQuarterlyGrowth")]
            public double? EarningsQuarterlyGrowth { get; set; }

            [JsonProperty("ebitda")]
            public long? Ebitda { get; set; }

            [JsonProperty("ebitdaMargins")]
            public double? EbitdaMargins { get; set; }

            [JsonProperty("enterpriseToEbitda")]
            public double? EnterpriseToEbitda { get; set; }

            [JsonProperty("enterpriseToRevenue")]
            public double? EnterpriseToRevenue { get; set; }

            [JsonProperty("enterpriseValue")]
            public long? EnterpriseValue { get; set; }

            [JsonProperty("exDividendDate")]
            public int? ExDividendDate { get; set; }

            [JsonProperty("exchange")]
            public string Exchange { get; set; }

            [JsonProperty("fiftyDayAverage")]
            public double? FiftyDayAverage { get; set; }

            [JsonProperty("fiftyTwoWeekHigh")]
            public double? FiftyTwoWeekHigh { get; set; }

            [JsonProperty("fiftyTwoWeekLow")]
            public double? FiftyTwoWeekLow { get; set; }

            [JsonProperty("financialCurrency")]
            public string FinancialCurrency { get; set; }

            [JsonProperty("firstTradeDateEpochUtc")]
            public int? FirstTradeDateEpochUtc { get; set; }

            [JsonProperty("fiveYearAvgDividendYield")]
            public double? FiveYearAvgDividendYield { get; set; }

            [JsonProperty("floatShares")]
            public long? FloatShares { get; set; }

            [JsonProperty("forwardEps")]
            public double? ForwardEps { get; set; }

            [JsonProperty("forwardPE")]
            public double? ForwardPE { get; set; }

            [JsonProperty("freeCashflow")]
            public long? FreeCashflow { get; set; }

            [JsonProperty("fullTimeEmployees")]
            public int? FullTimeEmployees { get; set; }

            [JsonProperty("gmtOffSetMilliseconds")]
            public int? GmtOffSetMilliseconds { get; set; }

            [JsonProperty("governanceEpochDate")]
            public int? GovernanceEpochDate { get; set; }

            [JsonProperty("grossMargins")]
            public double? GrossMargins { get; set; }

            [JsonProperty("grossProfits")]
            public long? GrossProfits { get; set; }

            [JsonProperty("heldPercentInsiders")]
            public double? HeldPercentInsiders { get; set; }

            [JsonProperty("heldPercentInstitutions")]
            public double? HeldPercentInstitutions { get; set; }

            [JsonProperty("impliedSharesOutstanding")]
            public long? ImpliedSharesOutstanding { get; set; }

            [JsonProperty("industry")]
            public string Industry { get; set; }

            [JsonProperty("industryDisp")]
            public string IndustryDisp { get; set; }

            [JsonProperty("industryKey")]
            public string IndustryKey { get; set; }

            [JsonProperty("lastDividendDate")]
            public int? LastDividendDate { get; set; }

            [JsonProperty("lastDividendValue")]
            public double? LastDividendValue { get; set; }

            [JsonProperty("lastFiscalYearEnd")]
            public int? LastFiscalYearEnd { get; set; }

            [JsonProperty("lastSplitDate")]
            public int? LastSplitDate { get; set; }

            [JsonProperty("lastSplitFactor")]
            public string LastSplitFactor { get; set; }

            [JsonProperty("longBusinessSummary")]
            public string LongBusinessSummary { get; set; }

            [JsonProperty("longName")]
            public string LongName { get; set; }

            [JsonProperty("marketCap")]
            public long? MarketCap { get; set; }

            [JsonProperty("maxAge")]
            public int? MaxAge { get; set; }

            [JsonProperty("messageBoardId")]
            public string MessageBoardId { get; set; }

            [JsonProperty("mostRecentQuarter")]
            public int? MostRecentQuarter { get; set; }

            [JsonProperty("netIncomeToCommon")]
            public long? NetIncomeToCommon { get; set; }

            [JsonProperty("nextFiscalYearEnd")]
            public int? NextFiscalYearEnd { get; set; }

            [JsonProperty("numberOfAnalystOpinions")]
            public int? NumberOfAnalystOpinions { get; set; }

            [JsonProperty("open")]
            public double? Open { get; set; }

            [JsonProperty("operatingCashflow")]
            public long? OperatingCashflow { get; set; }

            [JsonProperty("operatingMargins")]
            public double? OperatingMargins { get; set; }

            [JsonProperty("overallRisk")]
            public int? OverallRisk { get; set; }

            [JsonProperty("payoutRatio")]
            public double? PayoutRatio { get; set; }

            [JsonProperty("pegRatio")]
            public double? PegRatio { get; set; }

            [JsonProperty("phone")]
            public string Phone { get; set; }

            [JsonProperty("previousClose")]
            public double? PreviousClose { get; set; }

            [JsonProperty("priceHint")]
            public int? PriceHint { get; set; }

            [JsonProperty("priceToBook")]
            public double? PriceToBook { get; set; }

            [JsonProperty("priceToSalesTrailing12Months")]
            public double? PriceToSalesTrailing12Months { get; set; }

            [JsonProperty("profitMargins")]
            public double? ProfitMargins { get; set; }

            [JsonProperty("quickRatio")]
            public double? QuickRatio { get; set; }

            [JsonProperty("quoteType")]
            public string QuoteType { get; set; }

            [JsonProperty("recommendationKey")]
            public string RecommendationKey { get; set; }

            [JsonProperty("recommendationMean")]
            public double? RecommendationMean { get; set; }

            [JsonProperty("regularMarketDayHigh")]
            public double? RegularMarketDayHigh { get; set; }

            [JsonProperty("regularMarketDayLow")]
            public double? RegularMarketDayLow { get; set; }

            [JsonProperty("regularMarketOpen")]
            public double? RegularMarketOpen { get; set; }

            [JsonProperty("regularMarketPreviousClose")]
            public double? RegularMarketPreviousClose { get; set; }

            [JsonProperty("regularMarketVolume")]
            public int? RegularMarketVolume { get; set; }

            [JsonProperty("returnOnAssets")]
            public double? ReturnOnAssets { get; set; }

            [JsonProperty("returnOnEquity")]
            public double? ReturnOnEquity { get; set; }

            [JsonProperty("revenueGrowth")]
            public double? RevenueGrowth { get; set; }

            [JsonProperty("revenuePerShare")]
            public double? RevenuePerShare { get; set; }

            [JsonProperty("sector")]
            public string Sector { get; set; }

            [JsonProperty("sectorDisp")]
            public string SectorDisp { get; set; }

            [JsonProperty("sectorKey")]
            public string SectorKey { get; set; }

            [JsonProperty("shareHolderRightsRisk")]
            public int? ShareHolderRightsRisk { get; set; }

            [JsonProperty("sharesOutstanding")]
            public long? SharesOutstanding { get; set; }

            [JsonProperty("sharesPercentSharesOut")]
            public double? SharesPercentSharesOut { get; set; }

            [JsonProperty("sharesShort")]
            public int? SharesShort { get; set; }

            [JsonProperty("sharesShortPreviousMonthDate")]
            public int? SharesShortPreviousMonthDate { get; set; }

            [JsonProperty("sharesShortPriorMonth")]
            public int? SharesShortPriorMonth { get; set; }

            [JsonProperty("shortName")]
            public string ShortName { get; set; }

            [JsonProperty("shortPercentOfFloat")]
            public double? ShortPercentOfFloat { get; set; }

            [JsonProperty("shortRatio")]
            public double? ShortRatio { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }

            [JsonProperty("symbol")]
            public string Symbol { get; set; }

            [JsonProperty("targetHighPrice")]
            public double? TargetHighPrice { get; set; }

            [JsonProperty("targetLowPrice")]
            public double? TargetLowPrice { get; set; }

            [JsonProperty("targetMeanPrice")]
            public double? TargetMeanPrice { get; set; }

            [JsonProperty("targetMedianPrice")]
            public double? TargetMedianPrice { get; set; }

            [JsonProperty("timeZoneFullName")]
            public string TimeZoneFullName { get; set; }

            [JsonProperty("timeZoneShortName")]
            public string TimeZoneShortName { get; set; }

            [JsonProperty("totalCash")]
            public long? TotalCash { get; set; }

            [JsonProperty("totalCashPerShare")]
            public double? TotalCashPerShare { get; set; }

            [JsonProperty("totalDebt")]
            public long? TotalDebt { get; set; }

            [JsonProperty("totalRevenue")]
            public long? TotalRevenue { get; set; }

            [JsonProperty("trailingAnnualDividendRate")]
            public double? TrailingAnnualDividendRate { get; set; }

            [JsonProperty("trailingAnnualDividendYield")]
            public double? TrailingAnnualDividendYield { get; set; }

            [JsonProperty("trailingEps")]
            public double? TrailingEps { get; set; }

            [JsonProperty("trailingPE")]
            public double? TrailingPE { get; set; }

            [JsonProperty("trailingPegRatio")]
            public double? TrailingPegRatio { get; set; }

            [JsonProperty("twoHundredDayAverage")]
            public double? TwoHundredDayAverage { get; set; }

            [JsonProperty("underlyingSymbol")]
            public string UnderlyingSymbol { get; set; }

            [JsonProperty("uuid")]
            public string Uuid { get; set; }

            [JsonProperty("volume")]
            public int? Volume { get; set; }

            [JsonProperty("website")]
            public string Website { get; set; }

            [JsonProperty("zip")]
            public string Zip { get; set; }
        }

        public class Root
        {
            [JsonProperty("data")]
            public Data Data { get; set; }

            [JsonProperty("message")]
            public string Message { get; set; }

            [JsonProperty("status")]
            public int? Status { get; set; }
        }
    }
}