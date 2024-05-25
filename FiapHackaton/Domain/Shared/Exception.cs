namespace FiapHackaton.Domain.Shared
{
   public class FiapHackaton : Exception
    {
        public FiapHackaton() { }
        public FiapHackaton(string message) : base(message) { }
        public FiapHackaton(string message, Exception inner) : base(message, inner) { }
    }
}
