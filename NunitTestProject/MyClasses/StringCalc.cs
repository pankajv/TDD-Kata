using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace MyClasses
{
    public class StringCalc
    {
        int _sum;
        char[] _delimiters=new char[2];

        public StringCalc()
        {
            _sum = 0;
            
        }

        public int Add(string strValue)
        {
            strValue.Trim();
            if (!string.IsNullOrEmpty(strValue))
            {
                _delimiters  = GetDelimiter(strValue);
            }
            return (string.IsNullOrEmpty(strValue) ? _sum : ((strValue).IndexOfAny(_delimiters) == -1 ? _sum + Convert.ToInt32(strValue) : SplitMultiple(strValue)));
        }

        public char[] GetDelimiter(string strValue)
        {
            if (strValue.IndexOf("//") > -1)
            {
                int index = strValue.IndexOf("//");
                return (strValue.Substring(index+2, 1).ToCharArray());
            }
            else
            {
                return new char[2] {',','\n'};
            }
        }

        private int SplitMultiple(string s)
        {
           
            s = GetStr(s);
            //Debug.WriteLine(s1);
            var arr = s.Split(_delimiters);
            foreach (var a in arr)
            {
                _sum = _sum + Convert.ToInt32(string.IsNullOrEmpty(a) ? 0 : Convert.ToInt32(a));
                //Debug.WriteLine(a);
            }
            
            return _sum;

        }

        private string GetStr(string s)
        {

            if (s.IndexOf("\n") > 0 && s.IndexOf("//") > -1)
                {
                   
                    int index = s.IndexOf("\n");
                    //Debug.WriteLine(index);
                    Debug.WriteLine(s.Substring(index + 1, (s.Length)-index-1));
                    return (s.Substring(index + 1, (s.Length) - index - 1));
                }
            
            else
            {
                return s;
            }
        }
    }
}
