using DDD.Domain.Repository;
using DDD.Domain.ValueObjects;
using DDD.Infrastructure.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WebForm.ViewModels
{
    public class WeatherLatestViewModel : ViewModelBase
    {
        private IWeatherRepository _weather;

        //引数なしだとSQLiteは自動的にnewされる
        public WeatherLatestViewModel()
            : this(new WeatherSQLite())
        { }

        public WeatherLatestViewModel(IWeatherRepository weather)
        {
            _weather = weather;
        }

        private string _areaIdText = string.Empty;
        public string AreaIdText 
        {
            get { return _areaIdText; }
            set
            {
                //if (_areaIdText == value)
                //{
                //    return;
                //}

                //_areaIdText = value;
                //OnPropertyChaned(_areaIdText);

                SetProperty(ref _areaIdText, value);
            }
        }

        private string _dateYmdText = string.Empty;
        public string DateYmdText
        {
            get { return _dateYmdText; }
            set 
            {
                SetProperty(ref _dateYmdText, value);
            }
        }

        private string _conditionText = string.Empty;
        public string ConditionText
        {
            get { return _conditionText; }
            set
            {
                SetProperty(ref _conditionText, value);
            }
        }

        private string _temperatureText = string.Empty;
        public string TemperatureText
        {
            get { return _temperatureText; }
            set
            {
                SetProperty(ref _temperatureText, value);
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        public void Search()
        {
            var entity = _weather.GetLatest(Convert.ToInt32(this.AreaIdText));

            if (entity != null)
            {
                DateYmdText = entity.DateYmd.ToString();
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;

            }

            //OnPropertyChaned("");
        }

        //public void OnPropertyChaned(string propertyName)
        //{
        //    //PropertyChangedがnullでなければInvoke
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
        
    }
}
