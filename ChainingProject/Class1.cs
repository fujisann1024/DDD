using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainingProject
{
    public class Class1
    {
        public static int Add(int a, int b)
        {
            if (a < 0)
            {
                throw new inputException("マイナス値は入力できない");
            }

            return a + b;
        }
    }
}
