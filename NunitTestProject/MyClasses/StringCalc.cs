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
        char[] _delimiters = new char[2];
        List<int> objNegativeCollection = new List<int>();

        public List<int> NegativeCollection
        {
            get { return objNegativeCollection; }
            set { objNegativeCollection = value; }
        }
        public StringCalc()
        {
            _sum = 0;
            objNegativeCollection.Clear();
        }



        public int Add(string strValue)
        {
            try
            {
                strValue.Trim();
                if (!string.IsNullOrEmpty(strValue))
                {
                    _delimiters = GetDelimiter(strValue);
                }
                return (string.IsNullOrEmpty(strValue) ? EvaluteForNegative(_sum) : ((strValue).IndexOfAny(_delimiters) == -1 ?CheckSingleNegativeValue( EvaluteForNegative(_sum + Convert.ToInt32(strValue))) : SplitMultiple(strValue)));
            }
            catch(Exception ex)
            {
                throw ex;
            
            }
        }

        public char[] GetDelimiter(string strValue)
        {
            if (strValue.IndexOf("//") > -1)
            {
                int index = strValue.IndexOf("//");
                return (strValue.Substring(index + 2, 1).ToCharArray());
            }
            else
            {
                return new char[2] { ',', '\n' };
            }
        }

        private int SplitMultiple(string s)
        {
            try
            {
                string message = "Negative not allowed:";
                int count = 0;
                s = GetStr(s);
                //Debug.WriteLine(s1);
                var arr = s.Split(_delimiters);
                foreach (var a in arr)
                {
                    _sum = _sum + EvaluteForNegative(string.IsNullOrEmpty(a) ? 0 : Convert.ToInt32(a));
                    // Debug.WriteLine(a);
                }

                if (this.NegativeCollection.Count > 0)
                {
                   // Debug.WriteLine(this.NegativeCollection.Count+"-----");
                    foreach (var n in this.NegativeCollection)
                    {
                        count++;
                        message = message + n.ToString();
                        if (count < this.NegativeCollection.Count)
                        {
                            message = message + ",";
                        }


                    }
                    throw new ArgumentException(message);
                }
                //Debug.WriteLine(_sum);
                return _sum;
            }
            catch (ArgumentException e)
            {

                throw e;
            }

        }

        private int EvaluteForNegative(object obj)
        {
            
            int i = Convert.ToInt32(obj);
            if (i < 0)
            {
                objNegativeCollection.Add(i);
            }
           
                return i;
             
        }

        private string GetStr(string s)
        {

            if (s.IndexOf("\n") > 0 && s.IndexOf("//") > -1)
            {

                int index = s.IndexOf("\n");
                //Debug.WriteLine(index);
                // Debug.WriteLine(s.Substring(index + 1, (s.Length)-index-1));
                return (s.Substring(index + 1, (s.Length) - index - 1));
            }

            else
            {
                return s;
            }
        }
        private int CheckSingleNegativeValue(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Negative are not allowed:" + value);
            }
            return value;
        }
    }
}
