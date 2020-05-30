using System;
using System.Runtime.InteropServices;
using DDD.Winform.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DDD.Winform.ViewModels;
using Moq;
using DDD.Domain.Repositories;
using System.Collections.Generic;
using DDD.Domain.Entities;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherLatestListVIewModelTest
    {
        [TestMethod]
        public void 天気一覧シナリオ()
        {
            var weatherMock = new Mock<IWeatherRepository>();

            var entities = new List<WeatherEntity>();
            entities.Add(new WeatherEntity(1,
                "東京",
                Convert.ToDateTime("2018/01/01 12:34:56"),
                2,
                12.3f));

            entities.Add(new WeatherEntity(2,
                "神戸",
                Convert.ToDateTime("2018/01/01 12:34:56"),
                1,
                22.1234f));


            weatherMock.Setup(x => x.GetData()).Returns(entities);

            var viewModel = new WeatherListViewModel(weatherMock.Object);
            viewModel.Weathers.Count.Is(2);

            viewModel.Weathers[0].AreaId.Is("0001");
            viewModel.Weathers[0].AreaName.Is("東京");
            viewModel.Weathers[0].DataDate.Is("2018/01/01 12:34:56");
            viewModel.Weathers[0].Condition.Is("曇り");
            viewModel.Weathers[0].Temparature.Is("12.30 ℃");
        }
    }
}
