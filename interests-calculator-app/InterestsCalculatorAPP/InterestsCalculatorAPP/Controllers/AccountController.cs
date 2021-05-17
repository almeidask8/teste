using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using InterestsCalculatorAPP.Domain.Model;
using InterestsCalculatorAPP.Service.Account;
using InterestsCalculatorAPP.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace InterestsCalculatorAPP.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILoginServices _ILoginServices;
        private IMapper _mapper;

        public AccountController(ILoginServices iLoginServices, IMapper mapper)
        {
            _ILoginServices = iLoginServices;
            _mapper = mapper;
        }

        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(LoginViewModel loginViewModel)
        {

            if (ModelState.IsValid)
            {
                var login = _mapper.Map<Login>(loginViewModel);
                var result = await _ILoginServices.Login(login);

                if(result == System.Net.HttpStatusCode.OK)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, loginViewModel.Email)
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                    return Redirect("/Home/calc");
                }
                else
                {
                    loginViewModel.Message = "Invalid Login, please try again.";
                }
            }
            
            return View(loginViewModel);
        }
    }
}