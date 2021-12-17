using static System.Int32;

namespace RegexApp.Model
{
    public abstract class Token
    {
        public int MinCount { get; set; } = 1;
        public int MaxCount { get; set; } = 1;
        public abstract bool isValid(char symbol);
        
        public enum TokenType
        {
            Letter, Number, Range, Symbol
        }
    }
}