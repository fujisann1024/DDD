using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Entities
{
    /// <summary>
    /// 計測エンティティ
    /// </summary>
    public class MeasureEntity
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="areaId">エリアID</param>
        /// <param name="measureDate">計測日時</param>
        /// <param name="measureValue">計測値</param>
        public MeasureEntity(
            int areaId
           ,DateTime measureDate
           ,float measureValue
            )
        {
            this.AreaId = new AreaId(areaId);
            this.MeasureDate = new MeasureDate(measureDate);
            this.MeasureValue = new MeasureValue(measureValue);
        }

        /// <summary>
        /// エリアID
        /// </summary>
        public AreaId AreaId { get; }

        /// <summary>
        /// 計測日時
        /// </summary>
        public MeasureDate MeasureDate { get; }

        /// <summary>
        /// 計測値
        /// </summary>
        public MeasureValue MeasureValue { get; }
    }
}
