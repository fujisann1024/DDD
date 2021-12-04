using DDD.Domain.Entities;
using DDD.Domain.Repository;
using DDD.WebForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace DDDTest.Tests
{
    [TestClass]
    public class LatestViewModelTest
    {
        [TestMethod]
        public void シナリオ()
        {
            var entity = new MeasureEntity(
                1,
                Convert.ToDateTime("2012/12/12 11:22:33"),
                12.34f
                );

            var measureMock = new Mock<IMeasureRepository>();
            measureMock.Setup(x => x.GetLatest()).Returns(entity);

            var vm = new LatestViewModel(measureMock.Object);

            //画面にエリアID・計測日時・計測値を表示

            vm.Serch();
            vm.AreaIdText.Is("0001");
            vm.MeasureDateText.Is("2012/12/12 11:22:33");
            vm.MeasureValueText.Is("12.34℃");


        }
    }
}
