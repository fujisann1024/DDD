using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Helpers;
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
    public class WeatherSaveViewModel : ViewModelBase
    {
        private IWeatherRepository _weather;
        private IAreasRepository _areas;

        public WeatherSaveViewModel()
            :this(new WeatherSQLite(), new AreasSQLite())
        {

        }

        public WeatherSaveViewModel(
            IWeatherRepository weather,
            IAreasRepository areas
            )
        {
            this._weather = weather;
            this._areas = areas;

            this.DateYmdValue = GetDateTime();
            this.SelectedCondition = Condition.Sunny.Value;
            this.TemperatureText = string.Empty;

            foreach (var area in areas.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }

        }

        public object SelectedAreaId { get; set; }
        public DateTime DateYmdValue { get; set; }
        public object SelectedCondition { get; set; }
        public string TemperatureText { get; set; }

        public BindingList<AreaEntity> Areas { get; set; }
         = new BindingList<AreaEntity>();
        public BindingList<Condition> Conditions { get; set; }
         = new BindingList<Condition>(Condition.ToList());
        public object TemperatureUnitName => Temperature.UnitName;

        public void Save()
        {
            Guard.IsNull(SelectedAreaId,"エリアを選択してください");
            var temperature = Guard.IsFloat(TemperatureText, "温度の入力に誤りがあります");

            var entity = new WheatherEntity(
                Convert.ToInt32(SelectedAreaId),
                DateYmdValue,
                Convert.ToInt32(SelectedCondition),
                temperature
                );

            _weather.Save(entity);
        }
    }
}
