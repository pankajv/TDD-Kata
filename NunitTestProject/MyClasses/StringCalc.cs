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
            strValue.Trim();

            if (string.IsNullOrEmpty(strValue))
            {
                return _sum + 0;
            }
            else
            {
                if ((strValue).IndexOf(',') == -1)
                    return _sum + Convert.ToInt32(strValue);
                else { 
                var arr=strValue.Split(',');
                    foreach(var a in arr )
                    {
                    _sum=_sum+ Convert.ToInt32(a);
                    }
                    return _sum;
                }
            }
        }
    }
}
