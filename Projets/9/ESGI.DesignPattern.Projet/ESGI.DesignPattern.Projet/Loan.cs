using System;
using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    public class Loan
    {
        
        private long MILLIS_PER_DAY = 86400000;
        private long DAYS_PER_YEAR = 365;
        protected const double RISK_FACTOR_FOR_RATING = 0.03;
        
        double _commitment;
        private DateTime? _expiry;
        private DateTime _start;
        private double _unusedPercentage;
        IList<Payment> _payments = new List<Payment>();

        public Loan(double commitment,
            DateTime start,
            DateTime? expiry,
            double unusedPercentage)
        {
            _expiry = expiry;
            _commitment = commitment;
            _start = start;
            _unusedPercentage = unusedPercentage;
        }

        public DateTime? GetExpiry()
        {
            return _expiry;
        }

        public double GetCommitment()
        {
            return _commitment;
        }

        public void Payment(double amount, DateTime paymentDate)
        {
            _payments.Add(new Payment(amount, paymentDate));
        }

        public DateTime? GetStart()
        {
            return _start;
        }

        public IList<Payment> Payments()
        {
            return _payments;
        }

        public double GetUnusedPercentage()
        {
            return _unusedPercentage;
        }

        public double Capital(CapitalStrategy capitalStrategy, DurationStrategy durationStrategy)
        {
            return capitalStrategy.Get(this, durationStrategy);
        }

        public double Duration(DurationStrategy durationStrategy)
        {
            return durationStrategy.Get(this);
        }
        
        protected double YearsTo(DateTime? endDate)
        {
            DateTime? beginDate = GetStart();
            return (double)((endDate?.Ticks - beginDate?.Ticks) / MILLIS_PER_DAY / DAYS_PER_YEAR);
        }

    }
}