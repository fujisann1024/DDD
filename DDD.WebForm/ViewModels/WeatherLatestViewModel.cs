using DDD.Domain.Entities;
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
        private IAreasRepository _areas;

        //引数なしだとSQLiteは自動的にnewされる
        public WeatherLatestViewModel()
            : this(new WeatherSQLite(), new AreasSQLite())
        { }

        public WeatherLatestViewModel(
            IWeatherRepository weather,
            IAreasRepository areas
            )
        {
            _weather = weather;
            _areas = areas;

            foreach (var area in areas.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }
        }

        private object _selecedAreaId;
        public object SelecedAreaId 
        {
            get { return _selecedAreaId; }
            set
            {
                //if (_areaIdText == value)
                //{
                //    return;
                //}

                //_areaIdText = value;
                //OnPropertyChaned(_areaIdText);

                SetProperty(ref _selecedAreaId, value);
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

        public BindingList<AreaEntity> Areas { get; set; }
        = new BindingList<AreaEntity>();

        //public event PropertyChangedEventHandler PropertyChanged;

        public void Search()
        {
            var entity = _weather.GetLatest(Convert.ToInt32(this._selecedAreaId));

            if (entity == null)
            {
                DateYmdText = string.Empty;
                ConditionText = string.Empty;
                TemperatureText = string.Empty;
            }
            else
            {
                DateYmdText = entity.DateYmd.ToString();
                ConditionText = entity.Condition.DisplayValue;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;
            }

        }

    }
}
