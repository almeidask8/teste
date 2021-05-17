using InterestsCalculatorAPI.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InterestsCalculatorAPI.Domain.Model
{
    public class InterestsCalculator
    {
        public double InitivalValue { get; set; }
        public int Time { get; set; }

        public async Task<double> GetFinalValue()
        {
            double result = 0;
            await Task.Factory.StartNew(() =>
            {
                result = Math.Round(InitivalValue * Math.Pow((1 + InterestsCalculatorUtils.CalculateInterestRate(1)), Time), 2);
            });
            return result;

        }
    }
}
