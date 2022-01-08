using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{

    public sealed class MeasureValue : ValueObject<MeasureValue>
    {
        public MeasureValue(float value)
        {
            Value = value;
        }

        public float Value { get; }

        protected override bool EqualsCore(MeasureValue other)
        {
            return Value == other.Value;
        }

        public string DisplayValue
        {
            get
            {
                return Math.Round(Value, 2) + "℃";
            }
        }
    }

}
