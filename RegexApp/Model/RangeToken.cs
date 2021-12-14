using System;

namespace RegexApp.Model
{
    public class RangeToken : Token
    {
        private int min;
        private int max;

        public RangeToken(string token)
        {
            token = token.Replace("[", "");
            token = token.Replace("]", "");
            token = token.Replace("-", "");
            var symbols = token.ToCharArray();
            if (symbols.Length != 2)
            {   //todo OUR EXCEPTION
                throw new Exception();
            }
            min = symbols[0];
            max = symbols[1];
            if (min > max)
            {
                throw new Exception();
            }
        }

        public override bool isValid(char symbol)
        {
            return min <= symbol && symbol <= max;
        }
    }
}