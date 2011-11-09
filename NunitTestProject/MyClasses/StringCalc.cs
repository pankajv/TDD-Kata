using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyClasses
{
    public class StringCalc
    {
        int _sum;

        public StringCalc()
        {
            _sum = 0;
        }

        public int Add(string strValue)
        {


            if (string.IsNullOrEmpty(strValue))
            {
                return _sum + 0;
            }
            else
            {
                return _sum + Convert.ToInt32(strValue);   
            }
        }
    }
}
