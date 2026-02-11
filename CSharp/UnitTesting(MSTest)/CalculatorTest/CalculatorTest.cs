using CalculatorCode.Feature;
namespace TestProject1
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Add_GivenTwoNum_ResultInt()
        {
            // Arrange
            var calculator=new Calculator();
            // Act
            int result = calculator.Add(6, 2);
            // Assert
            Assert.AreEqual(8, result);
        }
        [TestMethod]
        [DataRow(2, 1, 3)]
        [DataRow(11, 3, 14)]
        [DataRow(5,5, 10)]
        public void Add_Parametrized(int a,int b,int expected)
        {
            //Arrange
            var calculator=new Calculator();
            // Act
            int result=calculator.Add(a,b);
            //Assert
            Assert.AreEqual(result, expected);
        }
    }
    [TestClass]
    public class SumOfNumTest
    {
        [TestMethod]
        public void SumOfNum_ResultInt()
        {
            var sum = new SumOfNNo();
            int result = sum.Sum(10);
            Assert.AreEqual(result,55);
        }
    }
}
