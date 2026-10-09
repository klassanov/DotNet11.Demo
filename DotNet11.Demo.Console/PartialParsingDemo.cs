using System.Globalization;
using System.Numerics;

namespace DotNet11.Demo.ConsoleApp
{
    internal class PartialParsingDemo
    {
        private string separator = ",";

        internal void Run()
        {
            NumberParsing<double>("3.15,4.7,5.244");
            Console.WriteLine();
            ValidPrefixParsing("120px");
        }

        private void NumberParsing<T>(ReadOnlySpan<char> dataRow) where T: INumber<T>
        {
            Console.WriteLine(@$"Parsing string ""{dataRow}""");

            while (!dataRow.IsEmpty)
            {
                if(!T.TryParsePartial(dataRow, NumberStyles.Float, CultureInfo.InvariantCulture, out T? parsed, out int numConsumedChars))
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

            if (!int.TryParsePartial(dataRow, NumberStyles.Integer, CultureInfo.InvariantCulture, out int parsed, out int numConsumedChars))
            {
                throw new FormatException();
            }

            PrintResult(parsed, numConsumedChars);
        }

        private void PrintResult<T>(T parsed, int consumed) where T: INumber<T>
        {
            Console.WriteLine($"Parsed: {parsed}, Consumed chars: {consumed}");
        }
    }
}
