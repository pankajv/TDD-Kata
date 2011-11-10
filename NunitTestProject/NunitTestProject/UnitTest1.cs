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
        [Test]
        [TestCase("-76")]
        public void Add_NegativeValuesString(string strValue)
        {
            string message = "Negative not allowed:";
            try
            {
                StringCalc objStringCalc = new StringCalc();
                int i = objStringCalc.Add(strValue);

                int count = 0;
                if (objStringCalc.NegativeCollection.Count > 0)
                    foreach (var n in objStringCalc.NegativeCollection)
                    {
                        count++;
                        message = message + n.ToString();
                        if (count < objStringCalc.NegativeCollection.Count)
                        {
                            message = message + ",";
                        }


                    }

                if (objStringCalc.NegativeCollection.Count > 0)
                {
                    //Assert.Pass(message);
                    throw new ArgumentException(message);
                }
                else
                {
                    throw new Exception(message);

                }
            }
            catch (ArgumentException ex)
            {

                Debug.WriteLine(ex.Message);
                Assert.Pass(message);
            }
            catch 
            {
                Debug.WriteLine("Method expecting negative as argument!");
                Assert.Fail("Method expecting negative as argument!");
            
            }
        }


    }
}
