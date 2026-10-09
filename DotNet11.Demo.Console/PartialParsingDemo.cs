using System.Globalization;

namespace DotNet11.Demo.ConsoleApp
{
    internal class PartialParsingDemo
    {
        private string separator = ",";

        internal void Run()
        {
            DoubleParsing("3.15,4.7,5.244");
            Console.WriteLine();
            ValidPrefixParsing("120px");
        }

        private void DoubleParsing(ReadOnlySpan<char> dataRow)
        {
            Console.WriteLine(@$"Parsing string ""{dataRow}""");

            while (!dataRow.IsEmpty)
            {
                if(!double.TryParsePartial(dataRow, NumberStyles.Float, CultureInfo.InvariantCulture, out double parsed, out int numConsumedChars))
                {
                    throw new FormatException();
                }

                PrintResult(parsed, numConsumedChars);

                dataRow = dataRow[numConsumedChars..];

                if (dataRow.StartsWith(separator))
                {
                    dataRow = dataRow [1..];
                }
            }
        }

        private void ValidPrefixParsing(ReadOnlySpan<char> dataRow)
        {
            Console.WriteLine(@$"Parsing string ""{dataRow}""");

            if (!double.TryParsePartial(dataRow, NumberStyles.Float, CultureInfo.InvariantCulture, out double parsed, out int numConsumedChars))
            {
                throw new FormatException();
            }

            PrintResult(parsed, numConsumedChars);
        }

        private void PrintResult(double parsed, int consumed)
        {
            Console.WriteLine($"Parsed: {parsed}, Consumed chars: {consumed}");
        }
    }
}
