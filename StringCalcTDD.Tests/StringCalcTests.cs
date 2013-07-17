using System;
using System.Collections.Generic;
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

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InputOfNegativeNumberThrowsExeceptionWithTheNumbersInMessage()
        {
            //Arrange
            var stringCalculator = new StringCalculator();

            //Act
            try
            {
                stringCalculator.Add("-1,2,-3");
            }
            catch(Exception exception)
            {
                //Assert
                Assert.AreEqual("negatives not allowed -1 -3", exception.Message);
                throw;
            }            
        }

        [TestMethod]
        public void InputOfNumbersGreaterThanThousandwillBeIgnoed()
        {
            //Arrange
            var stringCalculator = new StringCalculator();

            //Act
            var result = stringCalculator.Add("1,2,1000");

            //Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void InputOfDemlimiterWithMultipleCharatersReturnsSum()
        {
            //Arrange
            var stringCalculator = new StringCalculator();

            //Act
            var result = stringCalculator.Add("//***\n1,2\n3***4");

            //Assert
            Assert.AreEqual(10, result);
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

            string[] delimiters;
            string stringWithoutAnyStartingDelimiter;
            if (numStr.Substring(0, 2) == "//")
            {
                var indexOfNewLine = numStr.IndexOf("\n", StringComparison.InvariantCulture);
                var newDelimiter = numStr.Substring(2,indexOfNewLine-2);
                delimiters = new[] {",", "\n", newDelimiter};
                stringWithoutAnyStartingDelimiter = numStr.Substring(indexOfNewLine+1);
            }
            else
            {
                delimiters = new[] { ",", "\n" };
                stringWithoutAnyStartingDelimiter = numStr;
            }

            IEnumerable<string> numberArray = stringWithoutAnyStartingDelimiter.Split(delimiters, StringSplitOptions.None);

            var negNumbersStr = numberArray.Where(s => int.Parse(s) < 0).Aggregate("", (current, s) => current + (s + " "));
            if(!String.IsNullOrEmpty(negNumbersStr))
                throw new Exception("negatives not allowed " + negNumbersStr.TrimEnd());

            numberArray = numberArray.Where(n => int.Parse(n) < 1000);

            return numberArray.Sum(number => int.Parse(number));
        }
    }
}
