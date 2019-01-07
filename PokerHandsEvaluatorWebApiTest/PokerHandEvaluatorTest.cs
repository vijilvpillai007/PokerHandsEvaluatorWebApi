using PokerHandsEvaluatorWebApi.BusinessService;
using PokerHandsEvaluatorWebApi.Constants;
using System;
using Xunit;

namespace PokerHandEvaluatorTestProjectNamespace
{
    public class PokerHandEvaluatorTest
    {
        private PokerHandEvaluatorService _pokerHandEvaluatorService;
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void EvaluatePokerHands_CheckNullorEmpty_ExceptionTest(string pokerHandsData)
        {
            var pokerHandsEvaluatorServiceObject = GetPokerHandEvaluatorObject();
            var actualResultException = Assert.Throws<Exception>(() => pokerHandsEvaluatorServiceObject.EvaluatePokerHands(pokerHandsData));
            var expectedResult = PokerConstants.InvalidInputMessage;
            Assert.Equal(expectedResult, actualResultException.Message);
        }

        [Theory]
        [InlineData("2c")]
        [InlineData("2c 6d")]
        [InlineData("2c 6d Td")]
        [InlineData("2c 6d Td Tc")]
        [InlineData("2c 6d Td Tc Js 2c")]
        [InlineData("2c 6d Td Tc Js 2c 2s")]
        public void EvaluatePokerHands_CheckPokerDataLength_LengthTest_ReturnsException(string pokerHandsData)
        {
            var pokerHandsEvaluatorServiceObject = GetPokerHandEvaluatorObject();
            var actualResultException = Assert.Throws<Exception>(() => pokerHandsEvaluatorServiceObject.EvaluatePokerHands(pokerHandsData));
            var expectedResult = PokerConstants.InvalidInputLengthMessage;
            Assert.Equal(expectedResult, actualResultException.Message);
        }

        [Theory]
        [InlineData("2c 6z Td Tc Js")]
        [InlineData("2c 6c Td Tc Jr")]
        [InlineData("2c 6c Td Tc Jp")]
        public void EvaluatePokerHands_CheckPokerData_SuitTests_ReturnsException(string pokerHandsData)
        {
            var pokerHandsEvaluatorServiceObject = GetPokerHandEvaluatorObject();
            var actualResultException = Assert.Throws<Exception>(() => pokerHandsEvaluatorServiceObject.EvaluatePokerHands(pokerHandsData));
            var expectedResult = PokerConstants.InvalidInputSuitsMessage;
            Assert.Equal(expectedResult, actualResultException.Message);
        }

        [Theory]
        [InlineData("cc 6d td tc js")]
        [InlineData("zc zd xd tc js")]
        [InlineData("zc zd xd rc js")]
        public void EvaluatePokerHands_CheckPokerData_RanksTest_ReturnsException(string pokerHandsData)
        {
            var pokerHandsEvaluatorServiceObject = GetPokerHandEvaluatorObject();
            var actualResultException = Assert.Throws<Exception>(() => pokerHandsEvaluatorServiceObject.EvaluatePokerHands(pokerHandsData));
            var expectedResult = PokerConstants.InvalidInputRanksMessage;
            Assert.Equal(expectedResult, actualResultException.Message);
        }

        [Theory]
        [InlineData("as ks qs js ts")]
        [InlineData("ac kc qc jc tc")]
        [InlineData("ad kd qd jd td")]
        [InlineData("ah kh qh jh th")]
        public void EvaluatePokerHands_CheckRoyalFlush_Test_ReturnsTrue(string pokerHandsData)
        {
            var pokerHandsEvaluatorServiceObject = GetPokerHandEvaluatorObject();
            string actualResult = pokerHandsEvaluatorServiceObject.EvaluatePokerHands(pokerHandsData);
            var expectedResult = PokerConstants.RoyalFlush;
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData("ac ks qs js ts")]
        [InlineData("as kc qc jc tc")]
        [InlineData("ah kd qd jd td")]
        [InlineData("ac kh qh jh th")]
        public void EvaluatePokerHands_CheckRoyalFlush_Test_ReturnsFalse(string pokerHandsData)
        {
            var pokerHandsEvaluatorServiceObject = GetPokerHandEvaluatorObject();
            string actualResult = pokerHandsEvaluatorServiceObject.EvaluatePokerHands(pokerHandsData);
            var expectedResult = PokerConstants.RoyalFlush;
            Assert.NotEqual(expectedResult, actualResult);
        }

        public PokerHandEvaluatorService GetPokerHandEvaluatorObject()
        {
            if (_pokerHandEvaluatorService == null)
            {
                _pokerHandEvaluatorService = new PokerHandEvaluatorService();
            }
            return _pokerHandEvaluatorService;
        }
    }
}
