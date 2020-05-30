using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Winform.ViewModels
{
    public class WeatherListViewModelWeather
    {
        private WeatherEntity _entity;
        public WeatherListViewModelWeather(WeatherEntity entity)
        {
            _entity = entity;
        }

        public string AreaId => _entity.AreaId.DisplayValue;
        public string AreaName => _entity.AreaName;
        public string DataDate => _entity.DataDate.ToString();
        public string Condition => _entity.Condition.DisplayValue;
        public string Temparature => _entity.Temparature.DisplayValueWithUnit;
    }
}
