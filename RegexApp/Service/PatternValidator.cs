using System;
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
            var currentTokenCount = 0;
            var symbolsCount = 0;
            while (symbolsCount < text.Length && currentToken != null)
            {
                if (currentToken.Value.isValid(text[symbolsCount]))
                {
                    symbolsCount++;
                    currentTokenCount++;
                }
                else
                {
                    if (currentTokenCount < currentToken.Value.minCount ||
                        currentTokenCount > currentToken.Value.maxCount)
                    {
                        return false;
                    }

                    currentTokenCount = 0;
                    currentToken = currentToken.Next;
                }
            }


            if (symbolsCount < text.Length)
            {
                return false;
            }

            switch (currentToken)
            {
                case null:
                    return true;
                default:
                    return !IsUnnecessaryTokens(currentToken.Next);
            }
        }

        private bool IsUnnecessaryTokens(LinkedListNode<Token> currentToken)
        {
            while (currentToken != null)
            {
                if (currentToken.Value.minCount != 0)
                {
                    return true;
                }

                currentToken = currentToken.Next;
            }

            return false;
        }
    }
}