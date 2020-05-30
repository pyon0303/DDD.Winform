using DDD.Domain.ValueObjects;
using System;

namespace DDD.Domain.Entities
{
    /// <summary>
    /// 完全コンストラクタパターン
    /// </summary>
    public sealed class WeatherEntity
    {
        public WeatherEntity(int areaId,
                            DateTime datadate,
                            int condition,
                            float temperature)
            :this(areaId,string.Empty,datadate,condition,temperature)
        {}

        public WeatherEntity(int areaId,
                    string areaName,
                    DateTime datadate,
                    int condition,
                    float temperature)
        {
            AreaId = new AreaId(areaId);
            AreaName = areaName;
            DataDate = datadate;
            Condition = new Condition(condition);
            Temparature = new Temparature(temperature);
        }

        public AreaId AreaId { get;}
        public string AreaName { get; }
        public DateTime DataDate { get;}
        public Condition Condition { get;}
        public Temparature Temparature { get;}

        public bool IsHot()
        {
            if(Condition == Condition.Sunny)
            {
                if (Temparature.Value > 30)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsOk()
        {
            if(DataDate < DateTime.Now.AddMonths(-1))
            {
                if (Temparature.Value < 10)
                    return false;
            }

            return true;
        }


    }
}
