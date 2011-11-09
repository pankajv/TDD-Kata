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
        [Test]
        [TestCase("")]
        public void Add_EmptyString(string strValue)
        {
            StringCalc objStringCalc = new StringCalc();
            Assert.AreEqual(-1, objStringCalc.Add(strValue));
        }
    }
}
