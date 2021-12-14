using System.Collections.Generic;
using System.Linq;
using RegexApp.Model;

namespace RegexApp.Service
{
    public static class PatternMatcherUtil
    {
        public static bool Match(string text, string pattern)
        {
            LinkedList<Token> tokens = new LinkedList<Token>();
            tokens.AddLast(new RangeToken("[A-C]"));
            tokens.AddLast(new LetterToken());
            tokens.AddLast(new NumberToken());
            tokens.AddLast(new RangeToken("[a-c]"));
            var patternValidator = new PatternValidator(tokens);
            return patternValidator.Validate(text);
        } 
    }
}