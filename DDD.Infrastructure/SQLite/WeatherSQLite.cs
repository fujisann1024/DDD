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

            using (var connection = new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@AreaId", areaId);
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        //EntityからValueObjectに自動的にnewする
                        return new WheatherEntity(
                            areaId,
                            Convert.ToDateTime(reader["DateYmd"]),
                            Convert.ToInt32(reader["Condition"]),
                            Convert.ToSingle(reader["Temperature"])
                            ); 
                    }
                }
            }

            return null;
        }
    }
}
