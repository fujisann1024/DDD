using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainingProject
{
    public sealed class inputException : Exception
    {
        public inputException(string message) : base(message)
        {

        }
    }
}
