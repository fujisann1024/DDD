using DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Entities
{
    //sealed～継承不可
    //完全コンストラクタ
    public sealed class WheatherEntity
    {
        //コンストラクタによってのみプロパティをセット
        public WheatherEntity(int areaId,
                              DateTime dateYmd,
                              int condition,
                              float temperature)
        {
            this.AreaId = areaId;
            this.DateYmd = dateYmd;
            this.Condition = new Condition(condition);
            //できるだけ早く値をValueObjectで受け取る
            this.Temperature = new Temperature(temperature);
        }

        //カプセル化
        public int AreaId { get; }
        public DateTime DateYmd { get; }
        public Condition Condition { get; }
        public Temperature Temperature { get; }

        public bool IsMousho()
        {
            if (Condition == Condition.Sunny)
            {
                if (Temperature.Value > 30)
                {
                    return true;
                }
            }
            return false;
        }

        //ロジックを保持
        public bool IsOK()
        {
            if (DateYmd < DateTime.Now.AddMonths(-1))
            {
                if (Temperature.Value < 10)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
