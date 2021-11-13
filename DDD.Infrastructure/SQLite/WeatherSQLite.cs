using DDD.Domain.Entities;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.SQLite
{
    public class WeatherSQLite : IWeatherRepository
    {
        
        public WheatherEntity GetLatest(int areaId)
        {
            //選択した地域の最新のデータを天気テーブルから1件取り出す
            string sql = @"SELECT DateYmd, Condition, Temperature FROM Weather
                           WHERE AreaId = @AreaID
                           ORDER BY DateYmd DESC
                           LIMIT 1";

            return SQLiteHelper.QuerySingle(
                sql,
                new List<SQLiteParameter>
                {
                    new SQLiteParameter("@AreaId", areaId)
                }.ToArray(),
                reader =>
                {
                    return new WheatherEntity(
                           areaId,
                           Convert.ToDateTime(reader["DateYmd"]),
                           Convert.ToInt32(reader["Condition"]),
                           Convert.ToSingle(reader["Temperature"])
                           );
                },
                null);
        }

        public IReadOnlyList<WheatherEntity> GetData()
        {
            string sql = @"SELECT A.AreaId,
                                  ifnull(B.AreaName,'') as AreaName,
                                  A.DateYmd,
                                  A.Condition,
                                  A.Temperature
                           FROM Weather A
                           LEFT OUTER JOIN Areas B
                           ON A.AreaId =B.AreaId";

            return SQLiteHelper.Query(sql,reader => {
                return new WheatherEntity(
                    Convert.ToInt32(reader["AreaId"]),
                    Convert.ToString(reader["AreaName"]),
                    Convert.ToDateTime(reader["DateYmd"]),
                    Convert.ToInt32(reader["Condition"]),
                    Convert.ToSingle(reader["Temperature"])
                    );
            });
        }

        public void Save(WheatherEntity weather)
        {
            string Insert = @"INSERT INTO Weather(AreaId,DateYmd,Condition,Temperature)
                              Values(@AreaId,@DateYmd,@Condition,@Temperature)";

            string Update = @"UPDATE Weather
                              SET Condition = @Condition,
                                  Temperature = @Temperature
                              WHERE AreaId = @AreaId
                              AND DateYmd = @DateYmd";

            var args = new List<SQLiteParameter>
            {

               new SQLiteParameter("@AreaId",weather.AreaId.Value),
               new SQLiteParameter("@DateYmd", weather.DateYmd),
               new SQLiteParameter("@Condition", weather.Condition.Value),
               new SQLiteParameter("@Temperature", weather.Temperature.Value),

            };

            SQLiteHelper.Execute(Insert,Update,args.ToArray());
        }
    }
}
