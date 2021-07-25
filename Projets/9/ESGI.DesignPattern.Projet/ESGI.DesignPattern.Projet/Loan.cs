using System;
using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    public class Loan
    {
        double _commitment;
        private DateTime? _expiry;
        private DateTime _start;
        private double _unusedPercentage;
        IList<Payment> _payments = new List<Payment>();
        private CapitalStrategy _capitalStrategy;

        private Loan(double commitment,
            DateTime start,
            DateTime? expiry,
            double unusedPercentage,
            CapitalStrategy capitalStrategy)
        {
            _expiry = expiry;
            _commitment = commitment;
            _start = start;
            _unusedPercentage = unusedPercentage;
            _capitalStrategy = capitalStrategy;
        }

        public static Loan NewTermLoan(double commitment, DateTime start)
        {
            return new Loan(commitment, start, null, 1.0, new CapitalStrategyTermLoan());
        }

        public static Loan NewRevolver(double commitment, DateTime start, DateTime expiry)
        {
            return new Loan(commitment, start, expiry, 1.0, new CapitalStrategyRevolver());
        }

        public static Loan NewAdvisedLine(double commitment, DateTime start, DateTime expiry)
        {
            return new Loan(commitment, start, expiry, 0.1, new CapitalStrategyAdvisedLine());
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

        public double Capital()
        {
            return _capitalStrategy.Capital(this);
        }

        public double Duration()
        {
            return _capitalStrategy.Duration(this);
        }

    }
}