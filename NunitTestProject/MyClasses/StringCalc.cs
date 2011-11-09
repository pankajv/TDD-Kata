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
            return (string.IsNullOrEmpty(strValue) ? _sum : ((strValue).IndexOf(',') == -1 ? _sum + Convert.ToInt32(strValue) : SplitMultiple(strValue)));
        }
        private int SplitMultiple(string s)
        {
            var arr = s.Split(',');
            foreach (var a in arr)
            {
                _sum = _sum + Convert.ToInt32(a);
            }
            return _sum;

        }
    }
}
