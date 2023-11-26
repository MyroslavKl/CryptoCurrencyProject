using CryptoCurr.Models;
using CryptoCurr.ViewModel;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for GraphicsView.xaml
    /// </summary>
    public partial class GraphicsView : UserControl, INotifyPropertyChanged
    {
        public SeriesCollection SeriesCollection { get; set; }
        public ObservableCollection<string> Labels { get; set; }
        private CryptoCurrencyContext db;
        public GraphicsView()
        {
            db = new();
            InitializeComponent();
            FillComboBox();

            DataContext = this;

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Price History",
                    Values = new ChartValues<double>()
                }
            };

            Labels = new ObservableCollection<string>();
        }
        public void UpdateChart(IEnumerable<double> prices)
        {
            SeriesCollection[0].Values.Clear();
            Labels.Clear();

            foreach (var price in prices)
            {
                SeriesCollection[0].Values.Add(price);
                Labels.Add(DateTime.Now.ToString("HH:mm:ss"));
            }

            OnPropertyChanged(nameof(SeriesCollection));
            OnPropertyChanged(nameof(Labels));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// /////
        /// </summary>
        public void FillComboBox()
        {
            var fillObject = db.Currencies.Select(x => x.Name);
            foreach (var item in fillObject)
            {
                Combo.Items.Add(item);
            }
        }

        public void FillDataGrid() {
            var query = from currency in db.Currencies
                        join market in db.Markets on currency.Id equals market.CryptoCurrencyId
                        join price in db.Prices on market.PriceId equals price.Id
                        join history in db.Histories on currency.Id equals history.CryptoCurrencyId
                        select new
                        {
                            MarketId = market.Id,
                            MarketName = market.Name,
                            CryptoCurrencyName = currency.Name,
                            CryptoCurrencySymbol = currency.Symbol,
                            CryptoCurrencyDescription = currency.Description,
                            PriceCost = price.Cost,
                            HistoryId = history.Id,
                            HistoryVolume = history.Volume,
                            HistoryChangePercent = history.ChangePersent
                        };
            try
            {
                var searchPrice = query.Where(x => x.CryptoCurrencyName == Combo.SelectedValue.ToString()).ToList();
                var priceValues = searchPrice.Where(option => option.CryptoCurrencyName == Combo.SelectedValue.ToString()).DistinctBy(p => p.PriceCost).Select(x => x.PriceCost);
                UpdateChart(priceValues);

                Data.ItemsSource = searchPrice;
            }
            catch (Exception) {
                MessageBox.Show("Choose any value");
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }
    }
}
