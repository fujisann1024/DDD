using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Exceptions
{
    public sealed class FakeException : ExceptionBase
    {
        public FakeException(string message, Exception ex)
            : base(message, ex)
        {

        }

        /// <summary>
        /// システム上は問題ないため正常
        /// </summary>
        public override ExceptionKind Kind => ExceptionKind.Info;
    }
}
