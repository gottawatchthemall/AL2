using System;

namespace ESGI.DesignPattern.Projet
{
    public class CapitalStrategyTermLoan : CapitalStrategy
    {
        private readonly double EPSILON = 0.001;

        public override double Get(Loan loan, DurationStrategy durationStrategy)
        {
            return loan.GetCommitment() * durationStrategy.Get(loan) * RISK_FACTOR_FOR_RATING;
        }
    }
}