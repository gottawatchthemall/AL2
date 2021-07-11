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
        private double _riskRating;
        private double _unusedPercentage;
        IList<Payment> _payments = new List<Payment>();

        public Loan(double commitment,
            DateTime start,
            DateTime? expiry,
            int riskRating,
            double unusedPercentage)
        {
            _expiry = expiry;
            _commitment = commitment;
            _today = null;
            _start = start;
            _riskRating = riskRating;
            _unusedPercentage = unusedPercentage;
        }

        public static Loan NewTermLoan(double commitment, DateTime start, int riskRating)
        {
            return new Loan(commitment, start, null, riskRating, 1.0);
        }

        public static Loan NewRevolver(double commitment, DateTime start, DateTime expiry, int riskRating)
        {
            return new Loan(commitment, start, expiry, riskRating, 1.0);
        }

        public static Loan NewAdvisedLine(double commitment, DateTime start, DateTime expiry, int riskRating)
        {
            if (riskRating > 3) return null;
            var advisedLine = new Loan(commitment, start, expiry, riskRating, 0.1);
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

        public double GetRiskRating()
        {
            return _riskRating;
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