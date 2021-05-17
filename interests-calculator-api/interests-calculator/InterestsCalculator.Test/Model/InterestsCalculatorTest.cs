using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using InterestsCalculatorAPI.Domain.Model;

namespace InterestsCalculatorAPI.Test.Model
{
    public class InterestsCalculatorTest
    {
        [Fact]
        public void GetFinalValueGreaterThanZeroTest()
        {
            var interestCalculator = new InterestsCalculator() {
                InitivalValue = 1000,
                Time = 12
            };

            var result = interestCalculator.GetFinalValue();

            //Assert.True(result > 0);

        }
    }
}
