using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        //*******************************CONSTRUCTOR*********************************
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new Dictionary<string, Stock>();

            FullName = fullName;

            EmailAddress = emailAddress;

            MoneyToInvest = moneyToInvest;

            BrokerName = brokerName;
        }

        //*******************************PROPERTIES**********************************
        private Dictionary<string, Stock> Portfolio { get; set; }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => Portfolio.Count;

        //*******************************CLASS METHODS*******************************
        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10_000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock.CompanyName, stock);
            }
        }//Working

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!Portfolio.ContainsKey(companyName))
            {
                string result = $"{companyName} does not exist.";
                return result;
            }

            Stock currStock = Portfolio[companyName];

            if (sellPrice < currStock.PricePerShare)
            {
                string result = $"Cannot sell {companyName}.";

                return result;
            }

            Portfolio.Remove(companyName);
            MoneyToInvest += sellPrice;
            string sellText = $"{companyName} was sold.";
            return sellText;
        }//Working

        public Stock FindStock(string companyName)
        {
            Stock currStock = Portfolio.FirstOrDefault(c => c.Key == companyName).Value;
            return currStock;
        }//Working

        public Stock FindBiggestCompany()//Working
        {
            if (Portfolio.Any())
            {
                Stock currStock = Portfolio.OrderByDescending(c => c.Value.MarketCapitalization).First().Value;
                return currStock;
            }

            return null;
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var stock in Portfolio)
            {
                sb.AppendLine(stock.Value.ToString());
            }

            string result = sb.ToString().Trim();
            return result;
        }
        //***************************************************************************
    }
}
