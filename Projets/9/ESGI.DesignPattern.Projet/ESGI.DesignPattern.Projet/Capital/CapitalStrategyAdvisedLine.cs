namespace ESGI.DesignPattern.Projet
{
    public class CapitalStrategyAdvisedLine : CapitalStrategy
    {
        public override double Get(Loan loan, DurationStrategy durationStrategy)
        {
            return loan.GetCommitment() * loan.GetUnusedPercentage() * durationStrategy.Get(loan) * RISK_FACTOR_FOR_RATING;
        }
    }
}