using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using MyClasses;

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
    }
}
