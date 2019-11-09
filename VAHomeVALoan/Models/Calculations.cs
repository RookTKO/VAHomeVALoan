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
        public string LoanPeriod { get; set; }
                                                                //   15-yr,   30-yr
        public double[] InterestRate { get; set; } = new double[2] { 0.03125, 0.03375 }; // default interest rate per year
        public double HomeInsurance { get; set; } = 0;
        public double PropertyTax { get; set; } = 0;
        public double PropertyTaxRate { get; set; } = 0.0108; // default property tax rate per year
        public double HOA { get; set; } = 0;
        public double ZipCode { get; set; }
        public double MonthlyPayment { get; set; }
        public double OtherDebts { get; set; } // all other monthly debts excluding montly morgage payment
        public double DebtToIncomeRatio { get; set; } = 0.36; // default max ratio of 36%
        public double AnnualIncome { get; set; }

        public double GetPrincipleAndInterest() // per month
        {   
			double i; // interest rate per month
			double loanLength; // loan lenth in months
            switch(LoanPeriod) {
                case "Fifteen":
                    i = InterestRate[0] / 12;
					loanLength = 15 * 12;
                    break;
                case "Thirty":
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
            this.MonthlyPayment = GetPrincipleAndInterest() + GetPropertyTax()/12 + HOA + HomeInsurance/12;
		    return MonthlyPayment;
	    }

        public double GetDebtToIncomeRatio() {
            return OtherDebts / (AnnualIncome / 12);
        }

        public double GetAffordableLoanAmount() {
            //DebtToIncomeRatio
            double monthly_income = this.AnnualIncome / 12;
            double principleAndInterest = (monthly_income * DebtToIncomeRatio) - (GetPropertyTax()/12 + HOA + HomeInsurance/12 + OtherDebts);

            double i; // interest rate per month
			double loanLength; // loan lenth in months
            switch(LoanPeriod) {
                case "Fifteen":
                    i = InterestRate[0] / 12;
					loanLength = 15 * 12;
                    break;
                case "Thirty":
                    i = InterestRate[1] / 12;
					loanLength = 30 * 12;
                    break;
                default:
                    i = 0;
					loanLength = 0;
                    break;
            }
            double numerator = i * Math.Pow(1 + i, loanLength);
            double denominator = Math.Pow(1 + i, loanLength) - 1;

            return Math.Ceiling(principleAndInterest * denominator / numerator);
        }
    }
}