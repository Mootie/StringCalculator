using System;
using System.Linq;
using Xunit;
using StringCalculator;

namespace StringCalculatorUT
{
    public class AddTest
    {
        [Fact]
        public void EmptyString()
        {
            Assert.Equal(Calculator.Add(""), 0);
        }

        [Fact]
        public void OneNumber()
        {
            Assert.Equal(Calculator.Add("1"), 1);
        }

        [Fact]
        public void TwoNumbers()
        {
            Assert.Equal(Calculator.Add("1,2"), 3);
        }

        [Fact]
        public void TenNumbers()
        {
            int expected = 0;
            string[] numbers = new string[10];
            for (int i = 0; i < numbers.Length; ++i)
            {
                numbers[i] = i.ToString();
                expected += i;
            }

            int actual = Calculator.Add(String.Join(",", numbers));

            Assert.Equal(actual, expected);
        }

        [Fact]
        public void NewlineDelimiter()
        {
            Assert.Equal(Calculator.Add("1\n2,3"), 6);
        }

        [Fact]
        public void VariableDelimiters()
        {
            Assert.Equal(Calculator.Add("//;\n" + "1;2"), 3);
        }

        [Fact]
        public void ThrowExceptionOnNegatives()
        {
            string[] expected = new string[] { "-2", "-4" };
            string exceptionMessage = "";
            try
            {
                Calculator.Add("1,-2,3,-4");
            }
            catch (ArgumentException ex)
            {
                exceptionMessage = ex.Message;
            }

            foreach (string expectedString in expected)
            {
                Assert.True(exceptionMessage.Contains(expectedString));
            }
        }

        [Fact]
        public void IgnoresNumbersGreaterThan1000()
        {
            Assert.Equal(Calculator.Add("2,1001"), 2);
        }

        [Fact]
        public void VariableLengthDelimiters()
        {
            Assert.Equal(Calculator.Add("//[***]\n1***2***3"), 6);
        }

        [Fact]
        public void MulitpleDelimiters()
        {
            Assert.Equal(Calculator.Add("//[*][%]\n1*2%3"), 6);
        }

        [Fact]
        public void MulitpleVariableLengthDelimiters()
        {
            Assert.Equal(Calculator.Add("//[**][%%]\n1**2%%3"), 6);
        }
    }
}
