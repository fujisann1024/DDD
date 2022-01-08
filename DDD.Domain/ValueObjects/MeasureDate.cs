using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{

    public sealed class MeasureDate : ValueObject<MeasureDate>
    {
        public MeasureDate(DateTime value)
        {
            Value = value;
        }

        public DateTime Value { get; }

        protected override bool EqualsCore(MeasureDate other)
        {
            return Value == other.Value;
        }

        public string DisplayValue
        {
            get
            {
                return Value.ToString("yyyy/MM/dd HH:mm:ss");
            }
        }
    }

}
