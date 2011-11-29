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
        char[] _delimiters = new char[10];
        List<int> objNegativeCollection = new List<int>();

        /// <summary>
        /// 
        /// </summary>
        public List<int> NegativeCollection
        {
            get { return objNegativeCollection; }
            set { objNegativeCollection = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public StringCalc()
        {
            _sum = 0;
            objNegativeCollection.Clear();
        }

        /// <summary>
        /// Returns sumation of values passed as  string contains all int values separated by some delimiters
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public int Add(string strValue)
        {
            try
            {
                strValue.Trim();
                if (!string.IsNullOrEmpty(strValue))
                {
                    _delimiters = GetDelimiter(strValue);
                }
                return (string.IsNullOrEmpty(strValue) ? EvaluteForNegative(_sum) : ((strValue).IndexOfAny(_delimiters) == -1 ? CheckSingleNegativeValue(EvaluteForNegative(_sum + Convert.ToInt32(strValue))) : SplitMultiple(strValue)));
            }
            catch (Exception ex)
            {
               // Debug.WriteLine("Add Method:" + ex.Message);
                throw ex;
            }
        }

        /// <summary>
        /// gives delimiters
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns>char array</returns>
        public char[] GetDelimiter(string strValue)
        {
            if (strValue.IndexOf('[') != strValue.LastIndexOf('['))
            {
                return GetMultipleDelimitersOfAnyLength(strValue.Substring(strValue.IndexOf('['), strValue.LastIndexOf(']')));
            }

            else if (strValue.IndexOf("//[") > -1)
            {
                int index = strValue.IndexOf("[");
                char c = strValue.Substring(index + 1, 1).ToCharArray()[0];

                char c1 = c;
                int i = 2;
                while (c == c1)
                {
                    c1 = strValue.Substring(index + i, 1).ToCharArray()[0];
                    i++;
                }
                return (strValue.Substring(index + 1, i - 2).ToCharArray());
            }
            else if (strValue.IndexOf("//") > -1)
            {
                int index = strValue.IndexOf("//");
                return (strValue.Substring(index + 2, 1).ToCharArray());
            }
            else
            {
                return new char[2] { ',', '\n' };
            }
        }

        /// <summary>
        /// Method splits multiple values(More than 2 values) and returns addition of separated values
        /// </summary>
        /// <param name="s"></param>
        /// <returns>Sum of Separarted  values</returns>
        private int SplitMultiple(string s)
        {
            try
            {
                string message = "Negative not allowed:";
                int count = 0;
                s = GetStr(s);
                var arr = s.Split(_delimiters);
                foreach (var a in arr)
                {
                    _sum = _sum + EvaluteForNegative(string.IsNullOrEmpty(a) ? 0 : Convert.ToInt32(a) > 1000 ? 0 : Convert.ToInt32(a));
                }

                if (this.NegativeCollection.Count > 0)
                {
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
                return _sum;
            }
            catch (ArgumentException e)
            {
                //Debug.WriteLine("Method name 'SplitMultiple()' has thrown an Exception::");
                throw e;
            }
        }

     
        
        /// <summary>
        /// Get Delimiters of any length and any kind.
        /// </summary>
        /// <param name="strValue">part of string contains all delimiters e.g. [*][%%]</param>
        /// <returns> char array</returns>
        private char[] GetMultipleDelimitersOfAnyLength(string strValue)
        {
            try
            {
                int index = 0;
                StringBuilder sb = new StringBuilder();
                while (1 == 1)
                {
                    if (strValue.IndexOf('[') >= 0)
                    {
                        if (strValue.IndexOf(']') >= 0)
                        {
                            foreach (char c in strValue.Substring(index + 1, strValue.IndexOf(']') - 1).ToCharArray())
                            {
                                sb.Append(c);
                            }
                            if (strValue.IndexOf(']') != strValue.LastIndexOf(']'))
                            {
                                strValue = strValue.Substring(strValue.IndexOf(']') + 1, (strValue.Length - strValue.LastIndexOf(']') + 1) + 1);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                return sb.ToString().ToCharArray();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Method name 'GetMultipleDelimitersOfAnyLength()' has thrown an Exception::" + ex.Message);
                return null;
            }
        }

        
        /// <summary>
        /// Evaluate negatives and adds into list collection of negative values.
        /// </summary>
        /// <param name="obj">-negative value as object</param>
        /// <returns></returns>
        private int EvaluteForNegative(object obj)
        {
            int i = Convert.ToInt32(obj);
            if (i < 0)
            {
                objNegativeCollection.Add(i);
            }
            return i;
        }

        /// <summary>
        /// Returns string after removal of portion that indicated delimiters
        /// </summary>
        /// <param name="s"> string as it is passed to Add method.</param>
        /// <returns></returns>
        private string GetStr(string s)
        {
            if (s.IndexOf("\n") > 0 && s.IndexOf("//") > -1 && s.IndexOf("[") > 0)
            {
                int index = s.LastIndexOf("]");
                string str = s.Substring(index + 1, (s.Length) - index - 1);
                return (str);
            }
            else if (s.IndexOf("\n") > 0 && s.IndexOf("//") > -1)
            {

                int index = s.IndexOf("\n");
                return (s.Substring(index + 1, (s.Length) - index - 1));
            }
            else
            {
                return s;
            }
        }

        /// <summary>
        /// check value for the given range e.g. 0 to 1000
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private int CheckSingleNegativeValue(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Negative are not allowed:" + value);
            }
            if (value > 1000)
                return 0;
            return value;
        }
    }
}
