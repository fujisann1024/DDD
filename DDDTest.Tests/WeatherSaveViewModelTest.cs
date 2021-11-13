﻿using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using DDD.Domain.Repository;
using DDD.WebForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherSaveViewModelTest
    {
        [TestMethod]
        public void 天気登録シナリオ()
        {
            var weatherMock = new Mock<IWeatherRepository>();
            var areasMock = new Mock<IAreasRepository>();

            var areas = new List<AreaEntity>();
            areas.Add(new AreaEntity(1, "東京"));
            areas.Add(new AreaEntity(2, "兵庫"));
            areasMock.Setup(x => x.GetData()).Returns(areas);

            var viewModelMock = new Mock<WeatherSaveViewModel>(weatherMock.Object,areasMock.Object);
            //オーバーライド
            viewModelMock.Setup(x => x.GetDateTime()).Returns(
                Convert.ToDateTime("2018/01/01 12:34:56")
                );
            
            var viewModel = viewModelMock.Object;
            //初期値のテスト
            viewModel.SelectedAreaId.IsNull();
            viewModel.DateYmdValue.Is(
                Convert.ToDateTime("2018/01/01 12:34:56")
                );
            viewModel.SelectedCondition.Is(1);
            viewModel.TemperatureText.Is("");
            viewModel.TemperatureUnitName.Is("℃");

            //コンボボックスのテスト
            viewModel.Areas.Count.Is(2);

            //コンディションのテスト
            viewModel.Conditions.Count.Is(4);

            //保存時のテスト(例外)         
            var ex = AssertEx.Throws<InputException>(() => viewModel.Save());
            ex.Message.Is("エリアを選択してください");

            viewModel.SelectedAreaId = 2;
            ex = AssertEx.Throws<InputException>(() => viewModel.Save());
            ex.Message.Is("温度の入力に誤りがあります");

            viewModel.TemperatureText = "12.345";

            weatherMock.Setup(x => x.Save(It.IsAny<WheatherEntity>())).
                Callback<WheatherEntity>(saveValue => 
                {
                    saveValue.AreaId.Value.Is(2);
                    saveValue.DateYmd.Is(Convert.ToDateTime("2018/01/01 12:34:56"));
                    saveValue.Condition.Value.Is(1);
                    saveValue.Temperature.Value.Is(12.345f);
                });

            viewModel.Save();
            weatherMock.VerifyAll();//テスト漏れを防ぐ
        }
    }
}
