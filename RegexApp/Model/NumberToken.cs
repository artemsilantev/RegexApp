namespace RegexApp.Model
{
    public class NumberToken : Token
    {
        public override bool isValid(char symbol)
        {
            return char.IsDigit(symbol);
        }
    }
}