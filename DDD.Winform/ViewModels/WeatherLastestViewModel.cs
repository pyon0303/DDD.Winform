using DDD.Domain.Entities;
using DDD.Domain.Repositories;
using DDD.Infrastructure.SQLite;
using DDD.Winform.Infrastructure.SQLite;
using System;
using System.ComponentModel;
using System.Security.Cryptography;

namespace DDD.Winform.ViewModels
{
    /// <summary>
    /// viewmodel
    /// </summary>
    public class WeatherLastestViewModel:ViewModelBase
    {
        /// <summary>
        /// Model to adaptable to mock, it is set as Interface
        /// </summary>
        private IWeatherRepository _weather;
        private IAreaRepository _areas;

        private object _selectedAreaId;
        private string _dataDateText  = string.Empty;
        private string _conditionText  = string.Empty;
        private string _temparatureText  = string.Empty;

        public WeatherLastestViewModel()
            : this(new WeatherSqLite(), new AreasSQLite())
        {

        }

        public WeatherLastestViewModel(
            IWeatherRepository weather,
            IAreaRepository areas)
        {
            _weather = weather;
            _areas = areas;

            foreach (var area in areas.GetData())
            {
                Areas.Add(new AreaEntity(area.AreaId, area.AreaName));
            }
        }

        public object SelectedAreaId
        {
            get { return _selectedAreaId; }
            set { SetProperty(ref _selectedAreaId, value); }
        }

        public string DataDateText
        {
            get { return _dataDateText; }
            set { SetProperty(ref _dataDateText, value); }
        }

        public string ConditionText
        {
            get { return _conditionText; }
            set { SetProperty(ref _conditionText, value); }
        }

        public string TemparatureText
        {
            get { return _temparatureText; }
            set { SetProperty(ref _temparatureText, value); }
        }

        /// <summary>
        /// WPFでいうObservableCollection 今回は表示のみなので
        /// </summary>
        public BindingList<AreaEntity> Areas { get; set; }
            = new BindingList<AreaEntity>();

        /// <summary>
        /// Viewからこのコードを呼び出してModelのGetLatestを呼ぶ
        /// </summary>
        public void Search()
        {
            var entity = _weather.GetLatest(Convert.ToInt32(_selectedAreaId));
            if (entity == null)
            {
                this.DataDateText = string.Empty;
                this.ConditionText = string.Empty;
                this.TemparatureText = string.Empty;
            }
            else
            {
                this.DataDateText = entity.DataDate.ToString();
                this.ConditionText = entity.Condition.DisplayValue;
                this.TemparatureText = entity.Temparature.DisplayValueWithUnit;
            }
        }

    }
}
