using System;
using System.Text.RegularExpressions;

namespace RegexApp.Model
{
    public class RangeToken : Token
    {
        private int min;
        private int max;

        public RangeToken(string token)
        {
            var originalToken = token;
            token = token.Replace("[", "");
            token = token.Replace("]", "");
            token = token.Replace("-", "");
            if (token.Length != 2)
            {
                throw new Exception($"Проблема с классом: {originalToken}");
            }

            min = token[0];
            max = token[1];
            if (min > max)
            {
                throw new Exception($"Минимальное значение '{token[0]}' не должно быть больше максимального '{token[1]}'");
            }
        }

        public override bool isValid(char symbol)
        {         
            return min <= symbol && symbol <= max;
        }
    }
}