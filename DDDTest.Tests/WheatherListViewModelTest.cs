﻿using DDD.Domain.Entities;
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
                        Convert.ToDateTime("2018/02/06 12:34:56"),
                        2,
                        12.3f
                    )
                );
            entities.Add(
                new WheatherEntity(
                        2,
                        Convert.ToDateTime("2018/02/06 12:34:56"),
                        1,
                        22.1234f
                    )
                );

            weatherMock.Setup(x => x.GetData()).Returns(entities);

          var viewModel = new WheatherListViewModel(weatherMock.Object);
            viewModel.Weathers.Count.Is(2);

        }
    }
}
