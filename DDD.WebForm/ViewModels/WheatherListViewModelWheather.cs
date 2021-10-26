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
        WheatherEntity _entity;


        public WheatherListViewModelWheather(WheatherEntity entity)
        {
            this._entity = entity;
        }
    }
}
