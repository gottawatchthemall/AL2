using System;

namespace ESGI.DesignPattern.Projet
{
    public class DurationStrategyDefault: DurationStrategy
    {
        private long MILLIS_PER_DAY = 86400000;
        private long DAYS_PER_YEAR = 365;
        
        public override double Get(Loan loan)
        {
            return YearsTo(loan.GetExpiry(), loan);
        }
    }
}