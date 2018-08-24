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
            string[] numbers = new string[10];
            int expected = 0;
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
    }
}
