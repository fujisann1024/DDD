using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Exceptions
{
    /// <summary>
    /// データの戻り値がNULLの場合、例外を発生させるクラス
    /// </summary>
    public sealed class DataNotExistsException : ExceptionBase
    {

        public DataNotExistsException()
            : base("データがありません")
        {

        }

        public override ExceptionKind Kind => ExceptionKind.Error;
    }
}
