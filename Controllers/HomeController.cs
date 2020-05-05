using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task5.Models;

namespace Task5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string firstNumber, string secondNumber)
        {
            ViewBag.Result = square(firstNumber, secondNumber);
            return View();
        }

        private static String square(string firstNum, string secondNum){
            int firstNumber = int.Parse(firstNum);
            int secondNumber = int.Parse(secondNum);
            string output = string.Empty;

            
            if (firstNumber < 0 || secondNumber < 0){
                output = "Enter only positive numbers i.e. numbers above zero";
            } else {
            
                double firstNumberSquareRoot = Math.Sqrt(firstNumber);
                double secondNumberSquareRoot = Math.Sqrt(secondNumber);

                if(firstNumberSquareRoot > secondNumberSquareRoot){
                    output = "The number "+ firstNumber + "with Square root "+ firstNumberSquareRoot +" has a higher square root than the number "+secondNumber +" with square root " + secondNumberSquareRoot;
                } else if (firstNumberSquareRoot < secondNumberSquareRoot){
                    output = "The number "+ secondNumber + "with Square root "+ secondNumberSquareRoot +" has a higher square root than the number "+firstNumber +" with square root " + firstNumberSquareRoot;
                } else if (firstNumberSquareRoot == secondNumberSquareRoot){
                    output = "You inputted similiar numbers, kindly ennter different numbers";
                }
            }

            return output;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
