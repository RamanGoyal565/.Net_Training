using System;
using System.Collections.Generic;
using System.Text;

namespace SensorData
{
    public interface IParser
    {
        public List<float>? Parser(string input);
    }
    public interface IRounder
    {
        float Round(float number);
    }
    public class SensorDataProcessor : IParser, IRounder
    {
        public List<float>? Parser(string input)
        {
            string[] parts = input.Split(',');
            List<float> numbers = new List<float>();
            foreach (string s in parts)
            {
                string value = s.Trim();
                if (string.IsNullOrWhiteSpace(value) ||
                     value.Equals("null", StringComparison.OrdinalIgnoreCase) ||
                     value.Equals("NaN", StringComparison.OrdinalIgnoreCase))
                    continue;
                if (float.TryParse(value, out float result))
                    numbers.Add(result);
            }
            if (numbers.Count == 0)
                return null;
            return numbers;
        }
        public float Round(float number)
        {
            return (float)Math.Round(number, 2);
        }

        public float[]? Process(string input)
        {
            var parsedNumbers = Parser(input);
            if (parsedNumbers == null)
                return null;
            List<float> rounded = new List<float>();
            foreach (var number in parsedNumbers)
            {
                rounded.Add(Round(number));
            }
            return rounded.ToArray();
        }
    }
}