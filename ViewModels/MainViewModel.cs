using IUR_Task3_assignment.Support;
using IUR_Task3_assignment.ValidationRules;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WeatherInfoCustomControl.Support;

namespace IUR_Task3_assignment.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<WeatherCardViewModel> WeatherCards { get; set; } = new ObservableCollection<WeatherCardViewModel>();
        private RelayCommand _addCityCommand;
        private string _cityToBeAdded = "";
        private bool _validationReturn = true;
       

        public RelayCommand AddCityCommand
        {
            get { return _addCityCommand ?? (_addCityCommand = new RelayCommand(AddCity, AddCityCanExecute)); }
        }

        private void AddCity(object obj)
        {
            if (ValidationReturn)
            {
                WeatherCards.Add(new WeatherCardViewModel(this, CityToBeAdded));
            }
            CityToBeAdded = "";
        }

        private bool AddCityCanExecute(object obj)
        { 
            return true;
        }

        public bool ValidationReturn
        {
            get => _validationReturn;
            set => SetProperty(ref _validationReturn, value);
        }
        public string CityToBeAdded
        {
            get => _cityToBeAdded;
            set => SetProperty(ref _cityToBeAdded, value);
        }

        public MainViewModel()
        {
            WeatherNet.Util.Api.ApiClient.ProvideApiKey("d40a88ffbe58ff59c782dd4237c43ace");

            WeatherCards.Add(new WeatherCardViewModel(this, "Praha"));
            WeatherCards.Add(new WeatherCardViewModel(this, "Brno"));
            WeatherCards.Add(new WeatherCardViewModel(this, "Ostrava"));
            WeatherCards.Add(new WeatherCardViewModel(this, "Jihlava"));
            WeatherCards.Add(new WeatherCardViewModel(this, "Rakovník"));

        }
    }
}
