using System;
using System.Collections.Generic;
using System.Text;

namespace InterestsCalculatorAPI.Domain.Utils
{
    public static class InterestsCalculatorUtils
    {
        public static double CalculateInterestRate(double interestRate)
        {
            return  interestRate / 100;
        }
    }
}
