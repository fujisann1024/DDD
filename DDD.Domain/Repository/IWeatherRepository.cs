﻿using DDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Repository
{
    public interface IWeatherRepository
    {
        WheatherEntity GetLatest(int areaId);
    }
}
