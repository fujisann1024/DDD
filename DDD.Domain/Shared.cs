using System;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain
{
    /// <summary>
    /// アプリケーションの状態を見るクラス
    /// </summary>
    public static class Shared
    {
        /// <summary>
        /// Fakeかどうか
        /// </summary>
        public static bool IsFake { get; } = ConfigurationManager.AppSettings["ISFake"] == "1";
       
    }
}
