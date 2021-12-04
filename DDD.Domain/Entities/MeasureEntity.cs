using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Entities
{
    public class MeasureEntity
    {
        public MeasureEntity(
            int areaId
           ,DateTime measureDate
           ,float measureValue
            )
        {
            this.AreaId = areaId;
            this.MeasureDate = measureDate;
            this.MeasureValue = measureValue;
        }

        /// <summary>
        /// エリアID
        /// </summary>
        public int AreaId { get; }

        /// <summary>
        /// 計測日時
        /// </summary>
        public DateTime MeasureDate { get; }

        /// <summary>
        /// 計測値
        /// </summary>
        public float MeasureValue { get; }
    }
}
