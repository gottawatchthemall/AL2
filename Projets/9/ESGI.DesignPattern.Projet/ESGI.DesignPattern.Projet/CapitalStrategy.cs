using System;

namespace ESGI.DesignPattern.Projet
{
    public abstract class CapitalStrategy
    {

        private long MILLIS_PER_DAY = 86400000;
        private long DAYS_PER_YEAR = 365;
        protected const double RISK_FACTOR_FOR_RATING = 0.03;

        public abstract double Capital(Loan loan);

        public virtual double Duration(Loan loan)
        {
            return YearsTo(loan.GetExpiry(), loan);
        }

        protected double YearsTo(DateTime? endDate, Loan loan)
        {
            DateTime? beginDate = loan.GetStart();
            return (double)((endDate?.Ticks - beginDate?.Ticks) / MILLIS_PER_DAY / DAYS_PER_YEAR);
        }
    }
}