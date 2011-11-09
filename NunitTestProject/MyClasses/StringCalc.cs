using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyClasses
{
    public class StringCalc
    {

        public int Add(string strValue)
        {
            if (string.IsNullOrEmpty(strValue))
            {
                return 0;
            }

            return -1;  // added just to fail our case

        }
    }
}
