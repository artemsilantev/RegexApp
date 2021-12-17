using System.Collections;
using System.Collections.Generic;
using System.Text;
using RegexApp.Model;

namespace RegexApp.Service
{
    public static class PatternMatcherUtil
    {
        private const string counters = "+*";

        public static bool Match(string text, string pattern)
        {
            var tokens = ParsePattern(pattern);
            var patternValidator = new PatternValidator(tokens);
            return patternValidator.Validate(text);
        }

        private static LinkedList<Token> ParsePattern(string pattern)
        {   var result = new LinkedList<Token>();
            var stringBuilder = new StringBuilder();
            var currentType = Token.TokenType.Symbol;
            for (var i = 0; i < pattern.Length; i++)
            {
                Token token = null;
                switch (pattern[i])
                {
                    case '\\':
                    {
                        stringBuilder.Append(pattern[i]);
                        i++;
                        var type = 'd'.Equals(pattern[i]) ? Token.TokenType.Number : Token.TokenType.Letter;
                        stringBuilder.Append(pattern[i]);
                        if (i + 1 < pattern.Length && counters.Contains(pattern[i+1].ToString()))
                        {
                            i++;
                            stringBuilder.Append(pattern[i]);
                        }
                        token = TokenFactory.buildToken(stringBuilder.ToString(), type);
                        break;
                    }
                    case '[':
                    {
                        var index = pattern.IndexOf(']', i);
                        stringBuilder.Append(pattern.Substring(i, index - i + 1));
                        i = index;
                        if (i + 1 < pattern.Length && counters.Contains(pattern[i+1].ToString()))
                        {
                            i++;
                            stringBuilder.Append(pattern[i]);
                        }
                        token = TokenFactory.buildToken(stringBuilder.ToString(), Token.TokenType.Range);
                        break;
                    }
                    default:
                    {
                        stringBuilder.Append(pattern[i]);
                        token = TokenFactory.buildToken(stringBuilder.ToString(), Token.TokenType.Symbol);
                        break;
                    }
                }
                result.AddLast(token);
                stringBuilder.Clear();
            }

            return result;
        }
    }
}