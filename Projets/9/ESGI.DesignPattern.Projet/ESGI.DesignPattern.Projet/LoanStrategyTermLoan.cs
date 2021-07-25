using System;

namespace ESGI.DesignPattern.Projet
{
    public class LoanStrategyTermLoan: Loan
    {
        private readonly double EPSILON = 0.001;

        public LoanStrategyTermLoan(double commitment, DateTime start, DateTime? expiry, double unusedPercentage) : base(commitment, start, expiry, unusedPercentage)
        {
        }
        public override double Capital()
        {
            return GetCommitment() * Duration() * RISK_FACTOR_FOR_RATING;
        }

        public override double Duration()
        {
            var weightedAverage = 0.0;
            var sumOfPayments = 0.0;

            if (Math.Abs(GetCommitment()) <= EPSILON)
            {
                return 0.0;
            }
            
            foreach (var payment in Payments())
            {
                sumOfPayments += payment.Amount;
                weightedAverage += YearsTo(payment.Date) * payment.Amount;
            }

            return weightedAverage / sumOfPayments;
        }
        
    }
}