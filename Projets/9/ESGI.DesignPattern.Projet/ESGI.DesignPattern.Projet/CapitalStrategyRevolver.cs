namespace ESGI.DesignPattern.Projet
{
    public class CapitalStrategyRevolver : CapitalStrategy
    {
        private const double UNUSED_RISK_FACTORS_FOR_RATING = 0.01;
        public override double Capital(Loan loan)
        {
            return loan.GetCommitment() * Duration(loan) * UNUSED_RISK_FACTORS_FOR_RATING;
        }
    }
}