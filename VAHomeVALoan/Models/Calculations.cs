using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VAHomeVALoan.Models
{
    public class Calculations
    {
        public string test = "hello testing";
        public double HousePrice { get; set; } = 0;
        public double DownPayment { get; set; } = 0;
        public LoanLength LoanPeriod { get; set; }

        public enum LoanLength
        {
            Fifteen = 15,
            Thirty = 30
        }
        //   15-yr,   30-yr
        public double[] InterestRate { get; set; } = new double[2] { 0.03125, 0.03375 }; // default interest rate per year
        public double HomeInsurance { get; set; } = 0;
        public double PropertyTax { get; set; } = 0;
        public double PropertyTaxRate { get; set; } = 0.0108; // default property tax rate per year
        public double HOA { get; set; } = 0;
        public double ZipCode { get; set; }
        public double MonthlyPayment { get; set; }

        public double GetPrincipleAndInterest(LoanLength LoanPeriod) // per month
        {   
			double i; // interest rate per month
			double loanLength; // loan lenth in months
            switch(LoanPeriod) {
                case LoanLength.Fifteen:
                    i = InterestRate[0] / 12;
					loanLength = 15 * 12;
                    break;
                case LoanLength.Thirty:
                    i = InterestRate[1] / 12;
					loanLength = 30 * 12;
                    break;
                default:
                    i = 0;
					loanLength = 0;
                    break;
            }
            double loanAmount = HousePrice - DownPayment;
            double numerator = i * Math.Pow(1 + i, loanLength);
            double denominator = Math.Pow(1 + i, loanLength) - 1;

            return Math.Ceiling(loanAmount * (numerator / denominator)); 
        }
        
        public double GetPropertyTax() // per year
        {
            this.PropertyTax = HousePrice * PropertyTaxRate;
            return PropertyTax;
        }
        
	    public double GetMonthlyPayment() {
            this.MonthlyPayment = GetPrincipleAndInterest(LoanPeriod) + this.PropertyTax/12 + HOA + HomeInsurance/12;
		    return MonthlyPayment;
	    }
    }
}