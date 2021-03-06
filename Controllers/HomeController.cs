﻿//Developed by Mbaya Emmanuel Baldwin (@emmaraj)

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Task5.Models;

namespace Task5.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Add() {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string firstNumber, string secondNumber) {
            ViewBag.Result = square(firstNumber, secondNumber);
            return View();
        }

        private static String square(string firstNum, string secondNum) {
            int firstNumber;
            int secondNumber;
            string output = string.Empty;


            if (firstNum == "" || secondNum == "") {
                output = "Kindly input values";
            }
            else if (int.TryParse(firstNum, out firstNumber) && (int.TryParse(secondNum, out secondNumber))) {
                if (firstNumber < 0 || secondNumber < 0) {
                    output = "Enter only positive numbers i.e. numbers above zero";
                }
                else {

                    double firstNumberSquareRoot = Math.Sqrt(firstNumber);
                    double secondNumberSquareRoot = Math.Sqrt(secondNumber);

                    if (firstNumberSquareRoot > secondNumberSquareRoot) {
                        output = "The number " + firstNumber + " with Square root " + firstNumberSquareRoot + " has a higher square root than the number " + secondNumber + " with square root " + secondNumberSquareRoot;
                    }
                    else if (firstNumberSquareRoot < secondNumberSquareRoot) {
                        output = "The number " + secondNumber + " with Square root " + secondNumberSquareRoot + " has a higher square root than the number " + firstNumber + " with square root " + firstNumberSquareRoot;
                    }
                    else if (firstNumberSquareRoot == secondNumberSquareRoot) {
                        output = "You inputted similiar numbers, kindly enter different numbers";
                    }
                }
            }
            else {
                output = "Only numbers are accepted please";
            }

            return output;
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
