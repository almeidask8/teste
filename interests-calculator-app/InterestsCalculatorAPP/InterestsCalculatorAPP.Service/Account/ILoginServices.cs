using InterestsCalculatorAPP.Domain.Model;
using System.Net;
using System.Threading.Tasks;

namespace InterestsCalculatorAPP.Service.Account
{
    public interface ILoginServices
    {
        Task<HttpStatusCode> Login(Login login);
    }
}