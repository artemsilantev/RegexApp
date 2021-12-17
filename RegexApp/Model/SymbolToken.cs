namespace RegexApp.Model
{
    public class SymbolToken : Token
    {
        private char _symbol;

        public SymbolToken(char symbol)
        {
            _symbol = symbol;
        }

        public override bool isValid(char symbol)
        {
            return _symbol.Equals(symbol);
        }
    }
}