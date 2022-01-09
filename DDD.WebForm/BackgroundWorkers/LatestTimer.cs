using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDD.WebForm.BackgroundWorkers
{
    internal static class LatestTimer
    {
        private static Timer _timer;

        /// <summary>
        /// 処理実行フラグ
        /// </summary>
        private static bool _isWork = false;

        static LatestTimer()
        {
            _timer = new Timer(Callback);
        }

        internal static void Start()
        {
            _timer.Change(10000,10000);
        }

        internal static void Stop()
        {
            _timer.Change(Timeout.Infinite, Timeout.Infinite);
        }

        internal static void Callback(object o)
        {
            if (_isWork)
            {
                return;
            }
            try
            {
                _isWork = true;

                ///処理の記述///
            }
            finally
            {
                //処理が終わればフラグをfalseに設定
                _isWork = false;
            }
        }
    }
}
