namespace PokerHandsEvaluatorWebApi.Constants
{
    public static class PokerConstants
    {
        public const string RoyalFlush = "Royal Flush";
        public const string HighCard = "High Card";
        public const string Pair = "Pair";
        public const string TwoPair = "Two pair";
        public const string ThreeOfaKind = "Three of a kind";
        public const string Straight = "Straight ";
        public const string Flush = "Flush ";
        public const string FullHouse = "Full house";
        public const string FourOfaKind = "Four of a kind";
        public const string StraightFlush = "Straight flush";
        public static char[] ValidPokerRanks = new char[13] { '2', '3', '4', '5', '6', '7', '8', '9', 't', 'j', 'q', 'k', 'a' };
        public static char[] ValidPokerSuits = new char[4] { 'c', 'd', 'h', 's' };
        public static char[] ValidRoyalFlush = new char[5] { 'q', 'j', 'k', 't', 'a' };

        #region Error Messages
        public const string InvalidInputMessage = "Invalid Input";
        public const string InvalidInputLengthMessage = "Invalid Input Length";
        public const string InvalidInputSuitsMessage = "Invalid Input Suits";
        public const string InvalidInputRanksMessage = "Invalid Input Ranks";
        #endregion

    }
}
