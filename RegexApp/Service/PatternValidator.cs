using System.Collections.Generic;
using RegexApp.Model;

namespace RegexApp.Service
{
    public class PatternValidator
    {
        private LinkedList<Token> _tokens;

        public PatternValidator(LinkedList<Token> tokens)
        {
            _tokens = tokens;
        }

        public bool Validate(string text)
        {
            var currentToken = _tokens.First;
            var i = 0;
            var currentTokenCount = 0;
            while (currentToken != null)
            {
                for (;
                    i < text.Length && currentTokenCount <= currentToken.Value.maxCount
                                    && currentToken.Value.isValid(text[i]);
                    i++, currentTokenCount++)
                {
                }

                if (text.Length == i)
                {
                    return currentToken.Next == null || IsAllTokensBeUnimportant(currentToken);
                }

                if (currentToken.Value.minCount > currentTokenCount)
                {
                    return false;
                }

                if (currentToken.Value.minCount == 0)
                {
                    currentToken = currentToken.Next;
                    continue;
                }

                currentToken = currentToken.Next;
                currentTokenCount = 0;
                if (currentToken == null || !currentToken.Value.isValid(text[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsAllTokensBeUnimportant(LinkedListNode<Token> currentToken)
        {
            while (currentToken != null)
            {
                if (currentToken.Value.minCount != 0)
                {
                    return false;
                }

                currentToken = currentToken.Next;
            }

            return true;
        }
    }
}