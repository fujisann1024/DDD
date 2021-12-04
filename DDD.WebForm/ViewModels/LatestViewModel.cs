﻿using DDD.Domain.Entities;
using DDD.Domain.Repository;
using DDD.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WebForm.ViewModels
{
    public class LatestViewModel : ViewModelBase
    {
        private IMeasureRepository _measureRepository;

        //private MeasureEntity _measure;
        private string _areaIdText = string.Empty;
        private string _measureDateText = string.Empty;
        private string _measureValueText = string.Empty;

        public LatestViewModel()
            :this(Factories.CreateMeasure())
        {

        }

        public LatestViewModel(IMeasureRepository measureRepository)
        {
            _measureRepository = measureRepository;
        }

        public string AreaIdText 
        {
            get { return this._areaIdText; }
            set { base.SetProperty(ref _areaIdText, value); }
        }

        public string MeasureDateText 
        {
            get { return _measureDateText; }
            set { base.SetProperty(ref _measureDateText, value); }
        }

        public string MeasureValueText 
        {
            get { return _measureValueText; }
            set { base.SetProperty(ref _measureValueText, value); }
        }

        public void Serch()
        {
           var measure = _measureRepository.GetLatest();
            AreaIdText = measure.AreaId.ToString().PadLeft(4, '0');
            MeasureDateText = measure.MeasureDate.ToString("yyyy/MM/dd HH:mm:ss");
            MeasureValueText = Math.Round(measure.MeasureValue, 2) + "℃";

        }
    }
}
