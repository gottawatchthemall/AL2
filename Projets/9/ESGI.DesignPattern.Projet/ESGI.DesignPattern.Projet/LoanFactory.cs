using System;
using System.IO;

namespace ESGI.DesignPattern.Projet
{
    public enum LoanType
    {
        TermLoan,
        RevolverLoan,
        AdvisedLineLoan
    }
    
    public class LoanFactory
    {
        public static Loan Create(LoanType loanType, double commitment, DateTime start, DateTime? expiry)
        {
            return loanType switch
            {
                LoanType.TermLoan => new Loan(commitment, start, 1.0),
                LoanType.RevolverLoan => new Loan(commitment, start, 1.0, expiry),
                LoanType.AdvisedLineLoan => new Loan(commitment, start, 0.1, expiry),
                _ => throw new InvalidDataException()
            };
        }
    }
}