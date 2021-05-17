using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterestsCalculatorAPP.ViewModels
{
    public class HomeViewModel
    {
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public double InitivalValue { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Time { get; set; }
        public double FinalValue { get; set; }

    }
}
