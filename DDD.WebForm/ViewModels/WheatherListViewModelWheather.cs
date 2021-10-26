using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WebForm.ViewModels
{
    //クラス名に関しては一覧情報→詳細ほ
    public class WheatherListViewModelWheather
    {
        /// <summary>
        /// エンティティ
        /// </summary>
        private WheatherEntity _entity;


        public WheatherListViewModelWheather(WheatherEntity entity)
        {
            this._entity = entity;
        }

        public string AreaId => _entity.AreaId.DisplayValue;
        public string AreaName => _entity.AreaName;
        public string DateYmd => _entity.DateYmd.ToString();
        public string Condition => _entity.Condition.DisplayValue;
        public string Temperature => _entity.Temperature.DisplayValueWithUnitSpace;
    }
}
