namespace ESGI.DesignPattern.Projet
{
    public class CapitalStrategyRevolver : CapitalStrategy
    {
        private const double UNUSED_RISK_FACTORS_FOR_RATING = 0.01;
        public override double Get(Loan loan, DurationStrategy durationStrategy)
        {
            return loan.GetCommitment() * durationStrategy.Get(loan) * UNUSED_RISK_FACTORS_FOR_RATING;
        }
    }
}