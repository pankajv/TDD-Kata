using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using MyClasses;
using System.Diagnostics;

namespace NunitTestProject
{
    [TestFixture]
    public class UnitTest1
    {
        /// <summary>
        ///  Test method to check empty string
        /// </summary>
        /// <param name="strValue"></param>
        [Test]
        [TestCase("")]
        public void Add_EmptyString(string strValue)
        {
            StringCalc objStringCalc = new StringCalc();
            Assert.AreEqual(0, objStringCalc.Add(strValue));
        }


        /// <summary>
        /// Test method to check string contains one value
        /// </summary>
        /// <param name="strValue"> </param>
        [Test]
        [TestCase("2")]
        public void Add_OneValueString(string strValue)
        {
            StringCalc objStringCalc = new StringCalc();
            Assert.AreEqual(2, objStringCalc.Add(strValue));
        }

        /// <summary>
        /// Test method to check string contains 2 values
        /// </summary>
        /// <param name="strValue"></param>
        [Test]
        [TestCase("2,4")]
        public void Add_TwoValueString(string strValue)
        {
            StringCalc objStringCalc = new StringCalc();
            Assert.AreEqual(6, objStringCalc.Add(strValue));
        }

        /// <summary>
        /// Test method to check string contains multiple values
        /// </summary>
        /// <param name="strValue"></param>
        [Test]
        [TestCase("2,4,9,10")]
        public void Add_MultipleValueString(string strValue)
        {
            StringCalc objStringCalc = new StringCalc();
            Assert.AreEqual(25, objStringCalc.Add(strValue));
        }

        /// <summary>
        /// Test method to check new lines between numbers 
        /// </summary>
        /// <param name="strValue"></param>
        [Test]
        [TestCase("2\n4,3,10")]
        public void Add_ValuesSeparatedWithNewLineAndCommasString(string strValue)
        {
            StringCalc objStringCalc = new StringCalc();
            Assert.AreEqual(19, objStringCalc.Add(strValue));
        }

        /// <summary>
        /// Test method to support different delimiters
        /// </summary>
        /// <param name="strValue"></param>
        [Test]
        [TestCase("//;\n1;2")]
        public void Add_ValuesSeparatedWithMultipleDelimitersString(string strValue)
        {
            StringCalc objStringCalc = new StringCalc();
            Assert.AreEqual(3, objStringCalc.Add(strValue));
        }

        /// <summary>
        /// Test method to support different delimiters
        /// </summary>
        /// <param name="strValue"></param>
        [Test, ExpectedException(typeof(ArgumentException))]
        [TestCase("-76,12,-43")]
        public void Add_NegativeValuesString(string strValue)
        {
            // string message = "Negative not allowed:";
            try
            {
                StringCalc objStringCalc = new StringCalc();
                int i = objStringCalc.Add(strValue);
                if (objStringCalc.NegativeCollection.Count <= 0)
                {
                    throw new Exception("Method expecting negative as argument!");
                }

            }
            catch (ArgumentException ex)
            {

                Debug.WriteLine(ex.Message);
                Assert.Pass(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Assert.Fail(ex.Message);

            }
        }

        [Test]
        [TestCase("1001,4,1005")]
        public void Add_GreaterThanSpecifiedValuesString(string strValue)
        {
            StringCalc objStringCalc = new StringCalc();

            Assert.AreEqual(4, objStringCalc.Add(strValue));
        }


    }
}
