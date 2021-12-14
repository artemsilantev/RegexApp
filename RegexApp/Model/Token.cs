using static System.Int32;

namespace RegexApp.Model
{
    public abstract class Token
    {
        public int minCount = 1;
        public int maxCount = MaxValue;
        public abstract bool isValid(char symbol);
    }
}