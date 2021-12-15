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
            for (int i = 0; i < text.Length && currentToken != null; i++)
            {
                symbolsCount = i;
                if (currentToken.Value.isValid(text[i]))
                {
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

            if (symbolsCount < text.Length - 1)
            {
                return false;
            }
            
            return !IsUnnecessaryTokens(currentToken);
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