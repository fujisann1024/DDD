using DDD.Domain.Entities;
using DDD.Domain.Repository;
using DDD.WebForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherLatestViewTest
    {
        [TestMethod]
        public void シナリオ()
        {
            //viewModel
            var weatherMock = new Mock<IWeatherRepository>();
            weatherMock.Setup(x => x.GetLatest(1)).Returns(
                new WheatherEntity(
                        1,
                        Convert.ToDateTime("2018/02/06 12:34:56"),
                        2,
                        12.3f
                    )
                );
            weatherMock.Setup(x => x.GetLatest(2)).Returns(
                new WheatherEntity(
                        2,
                        Convert.ToDateTime("2018/02/06 12:34:56"),
                        1,
                        22.1234f
                    )
                );

            var areasMock = new Mock<IAreasRepository>();

            var areas = new List<AreaEntity>();
            areas.Add(new AreaEntity(1, "東京"));
            areas.Add(new AreaEntity(2, "兵庫"));
            areas.Add(new AreaEntity(3, "沖縄"));
            areasMock.Setup(x => x.GetData()).Returns(areas);

            var viewModel = new WeatherLatestViewModel(
                weatherMock.Object,//前回作成分
                areasMock.Object   //今回作成分
                );


            //初期状態で画面に文字が表示されないかどうか
            Assert.IsNull(viewModel.SelecedAreaId);
            Assert.AreEqual("",viewModel.DateYmdText);
            Assert.AreEqual("",viewModel.ConditionText);
            Assert.AreEqual("",viewModel.TemperatureText);

            //Mockを使ったテスト
            //直近値を選択したら画面に表示される
            viewModel.SelecedAreaId = 1;
            viewModel.Search(); //SQLiteに接続してデータを習得(仮)
            Assert.AreEqual(1, viewModel.SelecedAreaId);
            Assert.AreEqual("2018/02/06 12:34:56", viewModel.DateYmdText);
            Assert.AreEqual("曇り", viewModel.ConditionText);
            Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);

            viewModel.SelecedAreaId = 2;
            viewModel.Search(); //SQLiteに接続してデータを習得(仮)
            Assert.AreEqual(2, viewModel.SelecedAreaId);
            Assert.AreEqual("2018/02/06 12:34:56", viewModel.DateYmdText);
            Assert.AreEqual("晴れ", viewModel.ConditionText);
            Assert.AreEqual("22.12 ℃", viewModel.TemperatureText);


            viewModel.SelecedAreaId = 3;
            viewModel.Search(); //SQLiteに接続してデータを習得(仮)
            Assert.AreEqual(3, viewModel.SelecedAreaId);
            Assert.AreEqual("", viewModel.DateYmdText);
            Assert.AreEqual("", viewModel.ConditionText);
            Assert.AreEqual("", viewModel.TemperatureText);


            //コンボボックスのテストケース
            Assert.AreEqual(3, viewModel.Areas.Count);
            Assert.AreEqual(1, viewModel.Areas[0].AreaId);
            Assert.AreEqual("東京", viewModel.Areas[0].AreaName);
            Assert.AreEqual(2, viewModel.Areas[1].AreaId);
            Assert.AreEqual("兵庫", viewModel.Areas[1].AreaName);
        }

        //internal class WeatherMock : IWeatherRepository
        //{
        //    public WheatherEntity GetLatest(int areaId) 
        //    {
        //        return new WheatherEntity(1, Convert.ToDateTime("2018/02/06 12:34:56"),2,12.3f); 
  
        //    }
        //}
    }
}
