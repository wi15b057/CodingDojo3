using CodingDojo4DataLib;
using CodingDojo4DataLib.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo3.ViewModel
{
    public class StockEntryViewModel : BaseViewModel
    {
        private double salespriceInEuro;
        private double purchasepriceInEuro;
        private StockEntry stockEntry;

        public String Name
        {
            get { return stockEntry.SoftwarePackage.Name; }
            set
            {
                stockEntry.SoftwarePackage.Name = value;
                OnChange("Name");
            }
        }

        public String Group
        {
            get { return stockEntry.SoftwarePackage.Category.Name; }
            set
            {
                stockEntry.SoftwarePackage.Category.Name = value;
                OnChange("Group");
            }
        }

        public double SalesPrice
        {
            get { return stockEntry.SoftwarePackage.SalesPrice; }
            set
            {
                stockEntry.SoftwarePackage.SalesPrice = value;
                OnChange("SalesPrice");
            }
        }

        public double PurchasePrice
        {
            get { return stockEntry.SoftwarePackage.PurchasePrice; }
            set
            {
                stockEntry.SoftwarePackage.PurchasePrice = value;
                OnChange("PurchasePrice");
            }
        }

        public int OnStock
        {
            get { return stockEntry.Amount; }
            set
            {
                stockEntry.Amount = value;
                OnChange("OnStock");
            }
        }

        public StockEntryViewModel()
        {
            this.stockEntry = new StockEntry();
            this.stockEntry.SoftwarePackage = new Software("");
            this.stockEntry.SoftwarePackage.Category = new Group();
            this.stockEntry.SoftwarePackage.Category.Name = "";
            this.stockEntry.SoftwarePackage.SalesPrice = 0;
            this.stockEntry.SoftwarePackage.PurchasePrice = 0;
        }

        public StockEntryViewModel(StockEntry entry)
        {
            this.stockEntry = entry;
            salespriceInEuro = entry.SoftwarePackage.SalesPrice;
            purchasepriceInEuro = entry.SoftwarePackage.PurchasePrice;
        }

        public void CalculateSalesPriceFromEuro(Currencies currency)
        {
            this.SalesPrice = CurrencyConverter.ConvertFromEuroTo(currency, salespriceInEuro);
        }

        public void CalculatePurchasePriceFromEuro(Currencies currency)
        {
            this.PurchasePrice = CurrencyConverter.ConvertFromEuroTo(currency, purchasepriceInEuro);
        }
    }
}