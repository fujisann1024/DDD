using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObjects
{
    //Valueオブジェクトを継承している型のみを指定するValueObject基底クラス
    public abstract class ValueObject<T> where T　: ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var vo = obj as T;
            if (obj == null)
            {
                return false;
            }

            return EqualsCore(vo);
        }

        // == !=に対応
        public static bool operator ==(ValueObject<T> vo1, ValueObject<T> vo2)
        {
            return Equals(vo1, vo2);
        }

        public static bool operator !=(ValueObject<T> vo1, ValueObject<T> vo2)
        {
            return Equals(vo1, vo2);
        }

        protected abstract bool EqualsCore(T other);

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
