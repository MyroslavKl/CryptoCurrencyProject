using CryptoCurr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoCurr.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private CryptoCurrencyContext dbContext;
        public HomeView()
        {
            dbContext = new();
            InitializeComponent();
            DbShow();

            TextBox.TextChanged += TxtSearch_TextChanged;
            TextBox1.TextChanged += TxtSearch1_TextChanged;
            UpdateDataGrid();
            UpdateDataGrid1();

        }

        public IEnumerable<object> DbShow()
        {
            IEnumerable<object> res = from price in dbContext.Prices
                                      join currency in dbContext.Currencies on price.Id equals currency.PriceId
                                      select new
                                      {
                                          price.Id,
                                          price.Cost,
                                          currency.Name,
                                          currency.Symbol,
                                          currency.Description
                                      };

            DbCurrency.ItemsSource = res.ToList();
            return res;
        }
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateDataGrid();
        }

        private void TxtSearch1_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateDataGrid1();
        }

        private void UpdateDataGrid()
        {
            string searchTerm = TextBox.Text.Trim(); 
            IEnumerable<object> res = from price in dbContext.Prices
                                      join currency in dbContext.Currencies on price.Id equals currency.PriceId
                                      where (currency.Name.Contains(searchTerm))
                                      select new
                                      {
                                          price.Id,
                                          price.Cost,
                                          currency.Name,
                                          currency.Symbol,
                                          currency.Description
                                      };

            DbCurrency.ItemsSource = res.ToList();
        }
        private void UpdateDataGrid1()
        {
            string searchTerm = TextBox1.Text.Trim();
            IEnumerable<object> res = from price in dbContext.Prices
                                      join currency in dbContext.Currencies on price.Id equals currency.PriceId
                                      where (currency.Symbol.Contains(searchTerm))
                                      select new
                                      {
                                          price.Id,
                                          price.Cost,
                                          currency.Name,
                                          currency.Symbol,
                                          currency.Description
                                      };

            DbCurrency.ItemsSource = res.ToList();
        }
    }
}
