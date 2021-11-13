using DDD.Domain.Entities;
using DDD.Domain.Repository;
using DDD.Domain.ValueObjects;
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
        private IAreasRepository _areas;

        public WeatherSaveViewModel(IAreasRepository areas)
        {
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
    }
}
