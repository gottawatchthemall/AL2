using System;

namespace ESGI.DesignPattern.Projet
{
    public abstract class CapitalStrategy
    {

        private long MILLIS_PER_DAY = 86400000;
        private long DAYS_PER_YEAR = 365;
        protected const double RISK_FACTOR_FOR_RATING = 0.03;

        public abstract double Get(Loan loan, DurationStrategy durationStrategy);

    }
}