using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.DZ
{
    public class IllegalArgumentException : Exception
    {
        public IllegalArgumentException(string message) : base(message) 
        {
            
        }
    }
}
