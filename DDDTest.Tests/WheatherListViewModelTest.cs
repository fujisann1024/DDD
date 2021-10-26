using DDD.Domain.Entities;
using DDD.Domain.Repository;
using DDD.WebForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DDDTest.Tests
{
    [TestClass]
    public class WheatherListViewModelTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var weatherMock = new Mock<IWeatherRepository>();

            var entities = new List<WheatherEntity>();
            entities.Add(
                new WheatherEntity(
                        1,
                        "東京",
                        Convert.ToDateTime("2018/02/06 12:34:56"),
                        2,
                        12.3f
                    )
                );
            entities.Add(
                new WheatherEntity(
                        2,
                        "神戸",
                        Convert.ToDateTime("2018/02/06 12:34:56"),
                        1,
                        22.1234f
                    )
                );

            weatherMock.Setup(x => x.GetData()).Returns(entities);

          var viewModel = new WheatherListViewModel(weatherMock.Object);
            viewModel.Weathers.Count.Is(2);
            viewModel.Weathers[0].AreaId.Is("0001");//0を４桁埋め
            viewModel.Weathers[0].AreaName.Is("東京");
            viewModel.Weathers[0].DateYmd.Is("2018/02/06 12:34:56");
            viewModel.Weathers[0].Condition.Is("曇り");
            viewModel.Weathers[0].Temperature.Is("12.30 ℃");



        }
    }
}
