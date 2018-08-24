using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        public static int Add(string numbers)
        {
            List<string> delimiters = new List<string> { "\n", "," };
            string[] tokens = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            int sum = 0;
            foreach (string token in tokens)
            {
                int number = Int32.Parse(token);
                sum += number;
            }
            return sum;
        }
    }
}
