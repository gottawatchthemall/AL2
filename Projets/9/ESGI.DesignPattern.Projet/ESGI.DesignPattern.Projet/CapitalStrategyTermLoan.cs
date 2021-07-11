using System;

namespace ESGI.DesignPattern.Projet
{
    public class CapitalStrategyTermLoan : CapitalStrategy
    {
        private readonly double EPSILON = 0.001;

        public override double Capital(Loan loan)
        {
            return loan.GetCommitment() * Duration(loan) * RISK_FACTOR_FOR_RATING;
        }

        public override double Duration(Loan loan)
        {
            var weightedAverage = 0.0;
            var sumOfPayments = 0.0;

            if (Math.Abs(loan.GetCommitment()) <= EPSILON)
            {
                return 0.0;
            }
            
            foreach (var payment in loan.Payments())
            {
                sumOfPayments += payment.Amount;
                weightedAverage += YearsTo(payment.Date, loan) * payment.Amount;
            }

            return weightedAverage / sumOfPayments;
        }
    }
}