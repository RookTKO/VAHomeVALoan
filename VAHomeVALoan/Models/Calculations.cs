using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VAHomeVALoan.Models
{
    public class Calculations
    {

        public double HousePrice { get; set; }
        public double DownPayment { get; set; }
        public LoanLength LoanPeriod { get; set; }
        public double InterestRate { get; set; }
        public double HomeInsurace { get; set; }
        public double PropertyTax { get; set; }
        public double HOA { get; set; }
        public double ZipCode { get; set; }
        public double MonthlyPayment { get; set; }
        public enum LoanLength
        {
             Male,
             Female
        }

        public Gender StudentGender { get; set; }
        public enum Gender
        {
            Male,
            Female
        }

    }
}