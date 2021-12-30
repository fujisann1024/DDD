using DDD.Domain;
using DDD.Domain.Entities;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.Fake
{
    public class MeasureFake : IMeasureRepository
    {

        /// <summary>
        /// CSVファイルのデータを取得
        /// </summary>
        /// <returns></returns>
        public MeasureEntity GetLatest()
        {
            try
            {
                var liens = File.ReadAllLines(Shared.FakePath + "MeasureFake.csv");

                var value = liens[0].Split(',');
                return new MeasureEntity(
                    Convert.ToInt32(value[0]),
                    Convert.ToDateTime(value[1]),
                    Convert.ToSingle(value[2])
                    );
            }
            catch{
                return new MeasureEntity(
                    10
                    , Convert.ToDateTime("2012/12/12 11:22:33")
                    , 123.34f
                    );

            }

        }
    }
}
