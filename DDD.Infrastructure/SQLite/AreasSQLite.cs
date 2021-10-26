using DDD.Domain.Entities;
using DDD.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.SQLite
{
    public class AreasSQLite : IAreasRepository
    {
        public IReadOnlyList<AreaEntity> GetData()
        {
            
            string sql = @"SELECT AreaId, AreaName FROM Areas";

            return SQLiteHelper.Query(sql,
                reader =>
                    {
                        return new AreaEntity(
                            Convert.ToInt32(reader["AreaId"]),
                            Convert.ToString(reader["AreaName"])
                        );
                    }
                );
        }
    }
}
