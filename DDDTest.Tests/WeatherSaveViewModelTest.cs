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
    public class WeatherSaveViewModelTest
    {
        [TestMethod]
        public void 天気登録シナリオ()
        {
            var areasMock = new Mock<IAreasRepository>();

            var areas = new List<AreaEntity>();
            areas.Add(new AreaEntity(1, "東京"));
            areas.Add(new AreaEntity(2, "兵庫"));
            areasMock.Setup(x => x.GetData()).Returns(areas);

            var viewModelMock = new Mock<WeatherSaveViewModel>(areasMock.Object);
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

            //コンボボックスのテスト
            viewModel.Areas.Count.Is(2);

            //コンディションのテスト
            viewModel.Conditions.Count.Is(4);

        }
    }
}
