using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InterestsCalculatorAPP.Models;
using Microsoft.AspNetCore.Authorization;
using InterestsCalculatorAPP.ViewModels;
using InterestsCalculatorAPP.Service.Calc;
using AutoMapper;
using InterestsCalculatorAPP.Domain.Model;

namespace InterestsCalculatorAPP.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICalcServices _ICalcServices;
        private readonly ILogger _logger;
        private IMapper _mapper;

        public HomeController(ICalcServices iCalcServices, ILogger<HomeController> logger, IMapper mapper)
        {
            _ICalcServices = iCalcServices;
            _logger = logger;
            _mapper = mapper;
        }

        public IActionResult calc()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> calc(HomeViewModel homeViewModel)
        {
            try
            {
                var interestsCalculator = _mapper.Map<InterestsCalculator>(homeViewModel);
                homeViewModel.FinalValue = await _ICalcServices.CalculateInterests(interestsCalculator);
            }
            catch (Exception ex)
            {
                _logger.LogError("Try running calc", ex);
                TempData["Message"] = "Cannot to calculate the interest";
            }

            return View(homeViewModel);
        }

        public async Task<IActionResult> ShowMeYourCode()
        {
            try
            {
                var result = await _ICalcServices.ShowMeYourCode();
                return Redirect(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Try running ShowMeYourCode", ex);
                TempData["Message"] = "Cannot to show the source code";
            }

            return Redirect("/Home/calc");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
