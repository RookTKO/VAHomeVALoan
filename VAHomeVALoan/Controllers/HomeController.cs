using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VAHomeVALoan.Models;

namespace VAHomeVALoan.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Results(/*Calculations model*/)
        {
            //var ResultsFromCalculations = new Calculations()
            //{
            //    MonthlyPayment = 10
            //};
            //string test = "Testing this partial result";
            //return PartialView("Results", "hello");
            ViewBag.TotalStudents = "10";

            return PartialView();

        }
    }
}