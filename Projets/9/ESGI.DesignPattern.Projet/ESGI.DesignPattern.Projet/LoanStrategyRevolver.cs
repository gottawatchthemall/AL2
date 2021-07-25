using System;

namespace ESGI.DesignPattern.Projet
{
    public class LoanStrategyRevolver: Loan
    {
        private const double UNUSED_RISK_FACTORS_FOR_RATING = 0.01;
        
        public LoanStrategyRevolver(double commitment, DateTime start, DateTime? expiry, double unusedPercentage) : base(commitment, start, expiry, unusedPercentage)
        {
        }
        public override double Capital()
        {
            return GetCommitment() * Duration() * UNUSED_RISK_FACTORS_FOR_RATING;
        }
        
    }
}