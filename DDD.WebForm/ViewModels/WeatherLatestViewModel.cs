using DDD.Domain.Repository;
using DDD.Domain.ValueObjects;
using DDD.Infrastructure.SQLite;
using DDD.WebForm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WebForm.ViewModels
{
    public class WeatherLatestViewModel
    {
        private IWeatherRepository _weather;

        //引数なしだとSQLiteは自動的にnewされる
        public WeatherLatestViewModel()
            : this(new WeatherSQLite())
        {

        }

        public WeatherLatestViewModel(IWeatherRepository weather)
        {
            _weather = weather;
        }

        public string AreaIdText { get; set; } = string.Empty;
        public string DateYmdText { get; set; } = string.Empty;
        public string ConditionText { get; set; } = string.Empty;
        public string TemperatureText { get; set; } = string.Empty;

        public void Search()
        {
            var entity = _weather.GetLatest(Convert.ToInt32(this.AreaIdText));

            if (entity != null)
            {
                DateYmdText = entity.DateYmd.ToString();
                ConditionText = entity.Condition.DisplayValue;

                //TemperatureText = 
                //    CommonFunc.RoundString(entity.Temperature, Temperature.TemperatureDecimalPoint)
                //    + " " + Temperature.TemperatureUnitName;
                TemperatureText = entity.Temperature.DisplayValueWithUnitSpace;

            }
        }
    }
}
