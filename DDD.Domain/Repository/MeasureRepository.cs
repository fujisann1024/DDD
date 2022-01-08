using DDD.Domain.Entities;
using DDD.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.Domain.Repository
{
    public sealed class MeasureRepository
    {
        private IMeasureRepository _repository;

        public MeasureRepository(IMeasureRepository repository)
        {
            this._repository = repository;
        }

        public MeasureEntity GetLatest()
        {
            var val1 = _repository.GetLatest();
            if (val1 == null)
            {
                throw new DataNotExistsException();
            }
            Thread.Sleep(1000);
            var val2 = _repository.GetLatest();
            Thread.Sleep(1000);
            var val3 = _repository.GetLatest();

            var sum =
                val1.MeasureValue.Value +
                val3.MeasureValue.Value +
                val3.MeasureValue.Value;

            var ave = sum / 3f;
            return new MeasureEntity(
                val3.AreaId.Value,
                val3.MeasureDate.Value,
                ave
                );
        }
    }
}
