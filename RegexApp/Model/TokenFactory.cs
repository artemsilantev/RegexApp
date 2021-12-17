using System;
using System.Linq;
using static System.Int32;

namespace RegexApp.Model
{
    public static class TokenFactory
    {
        public static Token buildToken(string token, Token.TokenType type)
        {
            switch (type)
            {
                case Token.TokenType.Letter:
                    return buildLetter(token);
                case Token.TokenType.Number:
                    return buildNumber(token);
                case Token.TokenType.Range:
                    return buildRange(token);
                case Token.TokenType.Symbol:
                    return buildSymbol(token);
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private static LetterToken buildLetter(string tokenString)
        {
            var token = new LetterToken();
            SetupTokenCount(token, tokenString.Last());
            return token;
        }

        private static NumberToken buildNumber(string tokenString)
        {
            var token = new NumberToken();
            SetupTokenCount(token, tokenString.Last());
            return token;
        }

        private static RangeToken buildRange(string tokenString)
        {
            var lastSymbol = tokenString.Last();
            if (lastSymbol != ']')
            {
                tokenString = tokenString.Remove(tokenString.IndexOf(lastSymbol));
            }

            var token = new RangeToken(tokenString);
            SetupTokenCount(token, lastSymbol);
            return token;
        }

        private static SymbolToken buildSymbol(string tokenString)
        {
            var token = new SymbolToken(tokenString[0]);
            SetupTokenCount(token, tokenString.Last());
            return token;
        }

        private static void SetupTokenCount(Token token, char counter)
        {
            switch (counter)
            {
                case '*':
                {
                    token.MinCount = 0;
                    token.MaxCount = MaxValue;
                    break;
                }
                case '+':
                {
                    token.MinCount = 1;
                    token.MaxCount = MaxValue;
                    break;
                }
            }
        }
    }
}