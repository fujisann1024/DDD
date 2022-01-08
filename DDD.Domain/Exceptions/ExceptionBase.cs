using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="message"></param>
        public ExceptionBase(string message):base(message)
        {

        }

        /// <summary>
        /// インナーエクセプション
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public ExceptionBase(string message, Exception exception)
            : base(message, exception)
        {

        }

        /// <summary>
        /// 継承先に実装させる
        /// </summary>
        public abstract ExceptionKind Kind { get; }

        public enum ExceptionKind 
        {
            /// <summary>
            /// 正常
            /// </summary>
            Info,
            /// <summary>
            ///　警告
            /// </summary>
            Warning,
            /// <summary>
            /// エラー
            /// </summary>
            Error
        }

    }
}
