using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VAHomeVALoan.Controllers
{
    public class Calculations : Controller
    {
        private int Zipcode = 98003;
        private double HousePrice = 600000.00;
        private double DownPayment = 100000.00;
        private int[] LoanTerm = new int[2] { 15, 30 };
        private double HomeInsurance = 2520.00; // per year 
        private double[] InterestRate = new double[2] { 0.03125, 0.03375};
        private double PropertyTaxRate = 0.0108;
        private double HOA = 67.00; // per month

        public double GetPrincipleAndInterest() 
        {   
			double i = InterestRate[1] / 12;
            double loanAmount = HousePrice - DownPayment;
            double numerator = i * Math.Pow(1 + i, LoanTerm[1] * 12);
            double denominator = Math.Pow(1 + i, LoanTerm[1] * 12) - 1;

            return Math.Ceiling(loanAmount * (numerator / denominator)); 
        }
        
        public double GetPropertyTax() // per year
        {
            return HousePrice * PropertyTaxRate;
        }
        
	    public static double GetMonthlyPayment() {
		    return GetMonthlyPrincipleAndInterest() + GetPropertyTax()/12 + HOA + HomeInsurance/12;
	    }
    }
}