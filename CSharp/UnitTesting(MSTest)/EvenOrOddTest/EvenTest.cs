using System;
using System.Collections.Generic;
using System.Text;
using EvenOrOdd;
namespace EvenOddTest
{
    [TestClass]
    public class EvenTest
    {
        [TestMethod]
        public void CheckEven_GivenNum_ReturnBool() 
        {
            var even = new Even();
            bool result = even.Check(6);
            Assert.IsTrue(result);
        }
        [TestMethod]
        [DataRow(1)]
        [DataRow(10)]
        [DataRow(5)]
        [DataRow(9)]
        [DataRow(35)]
        public void CheckEven_Parameterised(int a)
        {
            var even = new Even();
            bool result = even.Check(a);
            Assert.IsTrue(result);
        }
    }
}
