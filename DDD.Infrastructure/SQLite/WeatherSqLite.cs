using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using DDD.Domain.Repositories;
using DDD.Domain.Entities;
using DDD.Infrastructure.SQLite;

namespace DDD.Winform.Infrastructure.SQLite
{
    public class WeatherSqLite: IWeatherRepository
    {
        public WeatherEntity GetLatest(int areaId)
        {
            string sql = @"select DataDate,
                           Condition,
                           Tempalature
                           from Weather 
                           where AreaId = @AreaId
                           order by DataDate desc
                           Limit 1";

            return SQLiteHelper.QuerySingle<WeatherEntity>(
                sql,
                new List<SQLiteParameter>
                { 
                    new SQLiteParameter(@"AreaId",areaId)
                }.ToArray(),
                reader => {

                    return new WeatherEntity(
                         areaId,
                         Convert.ToDateTime(reader["DataDate"]),
                         Convert.ToInt32(reader["Condition"]),
                         Convert.ToSingle(reader["Tempalature"]));

                },
                null);
            
        }

        public IReadOnlyList<WeatherEntity> GetData()
        {
            string sql = @"
                        select   A.AreaId,
                                 ifnull(B.AreaName,'') as AreaName,
                                 A.DataDate,
                                 A.Condition,
                                 A.Tempalature
                        from Weather A
                        left outer join Areas B
                        on A.AreaId = B.AreaId
                        ";

            return SQLiteHelper.Query(sql,
                reader =>
                {
                    return new WeatherEntity(
                           Convert.ToInt32(reader["AreaId"]),
                           Convert.ToString(reader["AreaName"]),
                           Convert.ToDateTime(reader["DataDate"]),
                           Convert.ToInt32(reader["Condition"]),
                           Convert.ToSingle(reader["Tempalature"]));
                });
        }

        public void Save(WeatherEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
