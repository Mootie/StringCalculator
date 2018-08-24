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
    }
}
