using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VAHomeVALoan.Models
{
    public class Calculations
    {

        public double HousePrice { get; set; } = 0;
        public double DownPayment { get; set; } = 0;
        public double LoanPeriod { get; set; }
                                                                //   15-yr,   30-yr
        public double[] InterestRate { get; set; } = new double[2] { 0.03125, 0.03375 }; // default interest rate per year
        public double HomeInsurace { get; set; } = 0;
        public double PropertyTax { get; set; } = 0;
        public double PropertyTaxRate { get; set; } = 0.0108; // default property tax rate per year
        public double HOA { get; set; } = 0;
        public double ZipCode { get; set; }
        public double MonthlyPayment { get; set; }

        public static double GetPrincipleAndInterest() // per month
        {   double i; // interest rate per month
            switch(LoanPeriod) {
                case 15:
                    i = InterestRate[0] / 12;
                    break;
                case 30:
                    i = InterestRate[1] / 12;
                    break;
                default:
                    i = 0;
                    break;
            }
            double loanAmount = HousePrice - DownPayment;
            double numerator = i * Math.Pow(1 + i, LoanPeriod * 12);
            double denominator = Math.Pow(1 + i, LoanPeriod * 12) - 1;

            return Math.Ceiling(loanAmount * (numerator / denominator)); 
        }
        
        public static double GetPropertyTax() // per year
        {
            this.PropertyTax = HousePrice * PropertyTaxRate;
            return PropertyTax;
        }
        
	    public static double GetMonthlyPayment() {
            this.MonthlyPayment = GetMonthlyPrincipleAndInterest() + this.PropertyTax/12 + HOA + HomeInsurance/12;
		    return MonthlyPayment;
	    }

    }
}