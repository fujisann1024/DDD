using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repository
{
    public interface IWeatherRepository
    {
        /// <summary>
        /// 直近値を取得するメソッド
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        WheatherEntity GetLatest(int areaId);

        /// <summary>
        /// 一覧を取得するメソッド
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<WheatherEntity> GetData();

        /// <summary>
        /// 天気データを保存するメソッド
        /// </summary>
        /// <param name="wheather"></param>
        void Save(WheatherEntity wheather);
    }
}
