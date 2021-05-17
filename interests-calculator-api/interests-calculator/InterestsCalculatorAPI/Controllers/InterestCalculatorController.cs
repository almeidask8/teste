using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterestsCalculatorAPI.Domain.Model;
using InterestsCalculatorAPI.Domain.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterestsCalculatorAPI.Controllers
{
    [ApiController]
    public class InterestCalculatorController : ControllerBase
    {
        [HttpGet("api/interest-rate/")]
        public IActionResult GetInterestRate()
        {
            return Ok(InterestsCalculatorUtils.CalculateInterestRate(1));        
        }

        [HttpPost("api/calc-interests/")]
        public async Task<IActionResult> PostInterest(InterestsCalculator interestCalculator)
        {
            var result = await interestCalculator.GetFinalValue();
            return Ok(result);
        }

        [HttpGet("api/show-me-your-code")]
        public IActionResult ShowMeYourCode()
        {
            return Ok("https://gitlab.com/carfilho/interests-calculator");
        }

    }
}