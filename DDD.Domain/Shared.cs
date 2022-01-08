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
        public static bool IsFake { get; } = ConfigurationManager.AppSettings["IsFake"] == "1";

        /// <summary>
        /// Fakeデータ(CSV)の格納先
        /// </summary>
        public static string FakePath { get; } = ConfigurationManager.AppSettings["FakePath"];

        /// <summary>
        /// ログイン会員のID
        /// </summary>
        public static string LoginId { get; set; } = string.Empty;
    }
}
