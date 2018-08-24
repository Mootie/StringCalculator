using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        private const string kDelimiterStringPrefix = "//";
        private const string kDelimiterStringSuffix = "\n";

        public static int Add(string numbers)
        {
            List<string> delimiters = new List<string> { "\n", "," };
            if (numbers.StartsWith(kDelimiterStringPrefix))
            {
                string delimiterString = numbers.Substring(kDelimiterStringPrefix.Length,
                                                           numbers.IndexOf(kDelimiterStringSuffix) - kDelimiterStringPrefix.Length);
                delimiters.AddRange(ParseDelimiterString(delimiterString));

                numbers = numbers.Substring(numbers.IndexOf(kDelimiterStringSuffix));
            }

            string[] tokens = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            List<int> operands = new List<int>();
            foreach (string token in tokens)
            {
                operands.Add(Int32.Parse(token));
            }

            int[] negatives = operands.Where((int operand) => operand < 0).ToArray();
            if (negatives.Length > 0)
            {
                throw new ArgumentException("Negatives not allowed, negatives found: " + String.Join(", ", negatives));
            }

            return operands.Sum();
        }
        
        private static List<string> ParseDelimiterString(string delimiterString)
        {
            List<string> delimiters = new List<string>();
            foreach (char delimiter in delimiterString)
            {
                delimiters.Add(delimiter.ToString());
            }
            return delimiters;
        }
    }
}
