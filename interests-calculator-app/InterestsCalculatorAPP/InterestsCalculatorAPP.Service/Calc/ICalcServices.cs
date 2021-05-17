using InterestsCalculatorAPP.Domain.Model;
using System.Threading.Tasks;

namespace InterestsCalculatorAPP.Service.Calc
{
    public interface ICalcServices
    {
        Task<double> CalculateInterests(InterestsCalculator interestsCalculator);
        Task<string> ShowMeYourCode();
    }
}