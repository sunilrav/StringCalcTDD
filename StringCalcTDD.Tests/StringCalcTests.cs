using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalcTDD.Tests
{
    [TestClass]
    public class StringCalcTests
    {
        [TestMethod]
        public void InputOfEmptyStringWillReturnZero()
        {
            //Arrange
            var stringCalculator = new StringCalculator();
            //Act
            var result = stringCalculator.Add("");

            //Assert
            Assert.AreEqual(0, result);
        }
    }

    public class StringCalculator
    {
        public int Add(string empty)
        {
            return 0;
        }
    }
}
