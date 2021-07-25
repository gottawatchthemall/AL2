using System;

namespace ESGI.DesignPattern.Projet
{
    public class LoanStrategyAdvisedLine: Loan
    {
        public LoanStrategyAdvisedLine(double commitment, DateTime start, DateTime? expiry, double unusedPercentage) : base(commitment, start, expiry, unusedPercentage)
        {
        }

        public override double Capital()
        {
            return GetCommitment() * GetUnusedPercentage() * Duration() * RISK_FACTOR_FOR_RATING;
        }
    }
}