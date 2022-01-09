using DDD.Domain.Entities;
using DDD.Domain.Repository;
using DDD.Domain.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.StaticValues
{
    public static class Measures
    {
        private static List<MeasureEntity> _entities 
            = new List<MeasureEntity>();

        public static void Create(IMeasureRepository repository)
        {
            //コレクションを途中でアクセスされると取得件数が0になってしまうためロックをかける
            lock (((ICollection)_entities).SyncRoot)
            {
                _entities.Clear();//最新のデータを取得するため
                _entities.AddRange(repository.GetLatests());
            }
        }

        /// <summary>
        /// コレクションを単体で取得するメソッド
        /// </summary>
        /// <param name="areaId"></param>
        /// <returns></returns>
        public static MeasureEntity GetLatest(AreaId areaId)
        {
            lock (((ICollection)_entities).SyncRoot)
            {
                return _entities.Find(x => x.AreaId == areaId);
            }
        }
    }
}
