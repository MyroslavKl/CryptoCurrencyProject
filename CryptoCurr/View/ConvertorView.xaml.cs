using CryptoCurr.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for ConvertorView.xaml
    /// </summary>
    public partial class ConvertorView : UserControl
    {
        private CryptoCurrencyContext db;
        public ConvertorView()
        {
            db = new();
            InitializeComponent();
            FillComboBoxes();
        }


        public void FillComboBoxes() {
            var fillObject = db.Currencies.Select(x => x.Symbol);
            foreach (var item in fillObject)
            {
                firstItem.Items.Add(item);
                secondItem.Items.Add(item);
            }
        }

        public void Find_Exchange()
        {
            var fillObject = from price in db.Prices
                             join currency in db.Currencies on price.Id equals currency.PriceId
                             select new
                             {
                                 price.Id,
                                 price.Cost,
                                 currency.Name,
                                 currency.Symbol,
                                 currency.Description
                             };
            try {
                var firstObject = fillObject.Where(x => x.Symbol == firstItem.SelectedValue.ToString()).ToList();
                var secondObject = fillObject.Where(x => x.Symbol == secondItem.SelectedValue.ToString()).ToList();
                double firstValue = 0.0, secondValue = 0.0;
                foreach (var item in firstObject)
                {
                    firstValue = item.Cost;
                }
                foreach (var item in secondObject)
                {
                    secondValue = item.Cost;
                }
                double result = firstValue / secondValue;
                result = Math.Round(result, 4);
                Rate.Text = result.ToString();
            }catch (Exception)
            {
                MessageBox.Show("Choose any value");

            }

        }

        private void BtnConvertor_Click(object sender, RoutedEventArgs e)
        {
            Find_Exchange();
            CalculationExchange();
        }

        public void CalculationExchange()
        {
            try
            {
                double exchangeValue = Convert.ToDouble(Rate.Text) * Convert.ToDouble(firstItemAmount.Text);
                secondItemAmount.Text = exchangeValue.ToString();
            }
            catch(Exception) {
                MessageBox.Show("Fill correct format");
            }
        }
    }
}
