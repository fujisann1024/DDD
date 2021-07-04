using DDD.Domain.Helpers;
using DDD.WebForm.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{
    //温度に関する値オブジェクト
    public sealed class Temperature : ValueObject<Temperature>
    {
        public static readonly string UnitName = "℃";

        public const int DecimalPoint = 2;

        public Temperature(float value)
        {
            this.Value = value;
        }

        public float Value { get; }

        //温度の表示のバリエーションを多く作っておく
        public string DisplayValue 
        { 
            get 
            {
                //可読性が上がる
                return Value.RoundString(DecimalPoint);
                //return FloatHelper.RoundString(Value, TemperatureDecimalPoint);
            } 
        }

        public string DisplayValueWithUnit
        {
            get
            {
                return Value.RoundString(DecimalPoint) + UnitName;
            }
        }

        public string DisplayValueWithUnitSpace
        {
            get
            {
                return Value.RoundString(DecimalPoint) + " " + UnitName;
            }
        }

        

        protected override bool EqualsCore(Temperature other)
        {
            return Value == other.Value;
        }
    }
}
