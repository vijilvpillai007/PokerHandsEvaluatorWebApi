using System;
using Microsoft.AspNetCore.Mvc;
using PokerHandsEvaluatorWebApi.Interfaces;

namespace PokerHandsEvaluatorWebApi.Controllers
{
    [Route("api/PokerHands")]
    [ApiController]
    public class PokerHandsController : ControllerBase
    {
        private readonly IPokerHandEvaluatorService _ipokerHandsService;
        public PokerHandsController(IPokerHandEvaluatorService ipokerHandsService)
        {
            this._ipokerHandsService = ipokerHandsService;
        }

        // GET api/PokerHands/EvaluatePokerHands?pokerData=ah kh qh jh th
        [HttpGet("EvaluatePokerHands")]
        [ActionName("EvaluatePokerHands")]
        public ActionResult Evaluate(string pokerData)
        {
            try
            {
                string pokerHandResult = _ipokerHandsService.EvaluatePokerHands(pokerData);
                return Ok(pokerHandResult);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
