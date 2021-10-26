using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WebForm.ViewModels
{
    public class WheatherListViewModel : ViewModelBase
    {

        private IWeatherRepository _weather;

        public WheatherListViewModel(IWeatherRepository weather)
        {
            _weather = weather;

            foreach (var entity in _weather.GetData())
            {
                Weathers.Add(new WheatherListViewModelWheather(entity));
            }
        }

        public BindingList<WheatherListViewModelWheather> Weathers { get; set; }
            = new BindingList<WheatherListViewModelWheather>();
    }
}
