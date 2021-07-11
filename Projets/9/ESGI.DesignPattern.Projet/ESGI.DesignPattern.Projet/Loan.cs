using System;
using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    public class Loan
    {
        double _commitment;
        private DateTime? _expiry;
        private DateTime? _today;
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
            _today = null;
            _start = start;
            _unusedPercentage = unusedPercentage;
        }

        public static Loan NewTermLoan(double commitment, DateTime start)
        {
            return new Loan(commitment, start, null, 1.0);
        }

        public static Loan NewRevolver(double commitment, DateTime start, DateTime expiry)
        {
            return new Loan(commitment, start, expiry, 1.0);
        }

        public static Loan NewAdvisedLine(double commitment, DateTime start, DateTime expiry)
        {
            var advisedLine = new Loan(commitment, start, expiry, 0.1);
            return advisedLine;
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

        public DateTime? GetToday()
        {
            return _today;
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
    }
}