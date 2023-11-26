using CryptoCurr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CryptoCurr.View
{
    /// <summary>
    /// Interaction logic for DetailsView.xaml
    /// </summary>
    public partial class DetailsView : UserControl
    {
        private CryptoCurrencyContext dbContext;
        public DetailsView()
        {
            dbContext = new();
            InitializeComponent();
            FillComboBox();
        }

        public void FillComboBox()
        {
            var fillObject = dbContext.Currencies.Select(x => x.Symbol);
            foreach (var item in fillObject)
            {
                Combo.Items.Add(item);
            }
        }

        public void FillDataGrid() {
            var query = from market in dbContext.Markets
                        join currency in dbContext.Currencies on market.CryptoCurrencyId equals currency.Id
                        join price in dbContext.Prices on market.PriceId equals price.Id
                        select new
                        {
                            MarketId = market.Id,
                            MarketName = market.Name,
                            CryptoCurrencyName = currency.Name,
                            CryptoCurrencySymbol = currency.Symbol,
                            CryptoCurrencyDescription = currency.Description,
                            PriceCost = price.Cost
                        };
            try
            {
                var searchInfo = query.Where(option => option.CryptoCurrencySymbol == Combo.SelectedValue.ToString()).ToList();
                Data.ItemsSource = searchInfo;
            }
            catch (Exception ex) {
                MessageBox.Show("Choose any value");
            }
            

           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }
    }
}
