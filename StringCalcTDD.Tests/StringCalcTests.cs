using System;
using System.Linq;
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

        [TestMethod]
        public void InputOfOneNumberWillReturnTheNumber()
        {
            //Arrange
            var stringCalculator = new StringCalculator();

            //Act
            var result = stringCalculator.Add("1");

            //Assert
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void InputOfTwoNumbersWillReturnTheSum()
        {
            //Arrange
            var stringCalculator = new StringCalculator();

            //Act
            var result = stringCalculator.Add("1,2");

            //Assert
            Assert.AreEqual(result, 3);
        }

        [TestMethod]
        public void InputOfThreeNumbersWillReturnSum()
        {
            //Arrange
            var stringCalculator = new StringCalculator();

            //Act
            var result = stringCalculator.Add("1,2,3");

            //Assert
            Assert.AreEqual(result, 6);
        }

    }

    public class StringCalculator
    {        
        public int Add(string numStr)
        {
            if(String.IsNullOrEmpty(numStr))
                return 0;

            var numberArray = numStr.Split(',');

            return numberArray.Length == 1 ? int.Parse(numberArray[0]) : numberArray.Sum(number => int.Parse(number));
        }
    }
}
