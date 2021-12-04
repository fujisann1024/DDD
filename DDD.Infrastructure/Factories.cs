using DDD.Domain;
using DDD.Domain.Repository;
using DDD.Infrastructure.Fake;
using DDD.Infrastructure.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure
{
    public static class Factories
    {

        public static IMeasureRepository CreateMeasure()
        {
        #if DEBUG
            if (Shared.IsFake)
            {
                return new MeasureFake();
            }
        #endif
            return new MeasureSQLite();
        }
    }
}
