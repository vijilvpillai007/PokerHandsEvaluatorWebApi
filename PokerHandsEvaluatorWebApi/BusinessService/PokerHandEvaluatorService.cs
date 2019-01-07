using PokerHandsEvaluatorWebApi.Constants;
using PokerHandsEvaluatorWebApi.Interfaces;
using System;
using System.Linq;

namespace PokerHandsEvaluatorWebApi.BusinessService
{
    public class PokerHandEvaluatorService : IPokerHandEvaluatorService
    {
        private string[] _pokerHands;
        private char[] _pokerRanks;
        private char[] _pokerSuits;
        public string EvaluatePokerHands(string pokerHandsData)
        {
            string pokerHandResult = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(pokerHandsData) && ValidatePokerData(pokerHandsData))
                {
                    if (ValidateRoyalFlush())
                    {
                        pokerHandResult = PokerConstants.RoyalFlush;
                    }
                }
                else
                {
                    throw new Exception(PokerConstants.InvalidInputMessage);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return pokerHandResult;

        }
        private bool ValidatePokerData(string pokerHandsData)
        {
            _pokerHands = pokerHandsData.ToLower().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            bool isValidPoker = false;
            if (_pokerHands.Length == 5)
            {
                _pokerRanks = _pokerHands.Where(s => !String.IsNullOrEmpty(s) && PokerConstants.ValidPokerRanks.Contains(s[0])).Select(s => s[0]).ToArray();
                _pokerSuits = _pokerHands.Where(s => !String.IsNullOrEmpty(s) && PokerConstants.ValidPokerSuits.Contains(s[1])).Select(s => s[1]).ToArray();
                if (_pokerRanks.Length == 5 && _pokerSuits.Length == 5)
                {
                    isValidPoker = true;
                }
                else if (_pokerRanks.Length != 5)
                {
                    throw new Exception(PokerConstants.InvalidInputRanksMessage);
                }
                else if (_pokerSuits.Length != 5)
                {
                    throw new Exception(PokerConstants.InvalidInputSuitsMessage);
                }
                else
                {
                    throw new Exception(PokerConstants.InvalidInputMessage);
                }
            }
            else
            {
                throw new Exception(PokerConstants.InvalidInputLengthMessage);
            }
            return isValidPoker;
        }
        private bool ValidateRoyalFlush()
        {
            bool royalRank = _pokerRanks.Where(s => PokerConstants.ValidRoyalFlush.Contains(s)).Select(s => s).Count() == 5 ? true : false;
            bool sameSuit = _pokerSuits.Distinct().Count() == 1 ? true : false;
            return royalRank && sameSuit;
        }
    }
}
