using System;

namespace ESGI.DesignPattern.Projet
{
    public class DurationStrategyTermLoan: DurationStrategy
    {
        private readonly double EPSILON = 0.001;

        public override double Get(Loan loan)
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
                weightedAverage += YearsTo(loan) * payment.Amount;
            }

            return weightedAverage / sumOfPayments;
        }
    }
}