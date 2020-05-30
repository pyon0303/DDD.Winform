using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Helpers;
using DDD.Domain.Repositories;
using DDD.Domain.ValueObjects;
using DDD.Infrastructure.SQLite;
using DDD.Winform.Infrastructure.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Winform.ViewModels
{
    public class WeatherSaveViewModel : ViewModelBase
    {

        private IAreaRepository _areas;
        private IWeatherRepository _weather;
        public object SelectedAreaId { get; set; }
        public DateTime DataDateValue { get; set; }
        public object SelectedCondition { get; set; }
        public string TemparatureText { get; set; }
        public BindingList<AreaEntity> Areas { get; set; }
            = new BindingList<AreaEntity>();

        public BindingList<Condition> Conditions { get; set; }
            = new BindingList<Condition>(Condition.ToList());
        public string TemparatureUnitName => Temparature.UnitName;

        public WeatherSaveViewModel()
            :this(new WeatherSqLite(), new AreasSQLite())
        {

        }

        public WeatherSaveViewModel(IWeatherRepository weather,IAreaRepository areas)
        {
            _areas = areas;
            _weather = weather;

            foreach (var area in areas.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }

            DataDateValue = GetDateTime();
            SelectedCondition = Condition.Sunny.Value;
            TemparatureText = string.Empty;
        }


        public void Save()
        {
            Guard.IsNull(SelectedAreaId, "エリアを選択してください");

            var temparature = Guard.IsFloat(TemparatureText, "温度の入力に誤りがあります");

            var entity = new WeatherEntity(
                Convert.ToInt32(SelectedAreaId),
                DataDateValue,
                Convert.ToInt32(SelectedCondition),
                temparature
                );
            _weather.Save(entity);
        }
    }
}
