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
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void InputOfTwoNumbersWillReturnTheSum()
        {
            //Arrange
            var stringCalculator = new StringCalculator();

            //Act
            var result = stringCalculator.Add("1,2");

            //Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void InputOfThreeNumbersWillReturnSum()
        {
            //Arrange
            var stringCalculator = new StringCalculator();

            //Act
            var result = stringCalculator.Add("1,2,3");

            //Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void InputStringWithNewLineDelimiterReturnsSum()
        {
            //Arrange
            var stringCalculator = new StringCalculator();

            //Act
            var result = stringCalculator.Add("1\n2,3");

            //Assert
            Assert.AreEqual(6, result);

        }

        [TestMethod]
        public void InputOfDelimiterChangerChangesTheDelimiterAndReturnsSum()
        {
            //Arrange
            var stringCalculator = new StringCalculator();

            //Act
            var result = stringCalculator.Add("//;\n1,2\n3");

            //Assert
            Assert.AreEqual(6, result);
        }

    }

    public class StringCalculator
    {        
        public int Add(string numStr)
        {
            if(String.IsNullOrEmpty(numStr))
                return 0;

            if (numStr.Length == 1)
                return int.Parse(numStr);

            char[] delimiters;
            string stringWithoutAnyStartingDelimiter;
            if (numStr.Substring(0, 2) == "//")
            {
                var newDelimiter = (char) numStr[2];
                delimiters = new char[] {',', '\n', newDelimiter};
                stringWithoutAnyStartingDelimiter = numStr.Substring(4);
            }
            else
            {
                delimiters = new char[] { ',', '\n' };
                stringWithoutAnyStartingDelimiter = numStr;
            }

            var numberArray = stringWithoutAnyStartingDelimiter.Split(delimiters);

            return numberArray.Sum(number => int.Parse(number));
        }
    }
}
