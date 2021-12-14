namespace RegexApp.Model
{
    public class LetterToken: Token
    {
        public override bool isValid(char symbol)
        {
            return char.IsLetter(symbol);
        }
    }
}