using CryptoCurr.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurr.ViewModel
{
    class MainViewModel :ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand DetailsViewCommand { get; set; }
        public RelayCommand GraphicsViewCommand { get; set; }
		public RelayCommand ConvertorViewCommand { get; set; }

        public HomeViewModel HomeVm { get; set; }
        public DetailViewModel DetailsVm { get; set; }
        public ConvertorViewModel ConvertorVm { get; set; }
		public GraphicsViewModel GraphicsVm { get; set; }

        private object _currentView;

		public object CurrentView
		{
			get { return _currentView; }
			set { _currentView = value;
				OnPropertyChanged();
			}
		}

		public MainViewModel() {
		HomeVm = new HomeViewModel();
			DetailsVm = new DetailViewModel();
			ConvertorVm = new ConvertorViewModel();
			GraphicsVm = new GraphicsViewModel();
			CurrentView = HomeVm;

			HomeViewCommand = new RelayCommand(o =>
			{
				CurrentView = HomeVm;
			});

			DetailsViewCommand = new RelayCommand(o => {
				CurrentView = DetailsVm;
			});

			GraphicsViewCommand = new RelayCommand(o => {
				CurrentView = GraphicsVm;
			});
			ConvertorViewCommand = new RelayCommand(o => {
				CurrentView = ConvertorVm;
			});

	    }
    }
}
