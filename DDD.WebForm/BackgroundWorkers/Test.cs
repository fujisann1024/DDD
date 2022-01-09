using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.WebForm.BackgroundWorkers
{
    class Test
    {
        public static void Main(string[] args)
        {
            double BMI = 23.0;
            string message = "";

            if (BMI < 18.5)
            {
                message = "少し痩せ気味です";
            }
            else if (BMI >= 18.5 && BMI < 25.0)
            {
                message = "正常です";
            }
            else if (BMI >= 25.0 && BMI < 30.0)
            {
                message = "少し太り気味です";
            }
            else
            {
                message = "肥満に注意してください";
            }

            Console.WriteLine(message);
        }
    }
}
