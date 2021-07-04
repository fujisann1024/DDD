using DDD.Domain.Entities;
using DDD.Domain.Repository;
using DDD.WebForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherLatestView
    {
        [TestMethod]
        public void シナリオ()
        {
            //viewModel
            var viewModel = new WeatherLatestViewModel(new WeatherMock());
            //初期状態で画面に文字が表示されないかどうか
            Assert.AreEqual("",viewModel.AreaIdText);
            Assert.AreEqual("",viewModel.DateYmdText);
            Assert.AreEqual("",viewModel.ConditionText);
            Assert.AreEqual("",viewModel.TemperatureText);
            //Mockを使ったテスト
            //直近値を選択したら画面に表示される
            viewModel.AreaIdText = "1";
            viewModel.Search(); //SQLiteに接続してデータを習得(仮)
            Assert.AreEqual("1", viewModel.AreaIdText);
            Assert.AreEqual("2018/02/06 12:34:56", viewModel.DateYmdText);
            Assert.AreEqual("曇り", viewModel.ConditionText);
            Assert.AreEqual("12.30 ℃", viewModel.TemperatureText);
        }

        internal class WeatherMock : IWeatherRepository
        {
            public WheatherEntity GetLatest(int areaId) 
            {
                return new WheatherEntity(1, Convert.ToDateTime("2018/02/06 12:34:56"),2,12.3f); 
  
            }
        }
    }
}
