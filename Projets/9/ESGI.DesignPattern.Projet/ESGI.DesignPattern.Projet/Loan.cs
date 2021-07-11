using System;
using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    public class Loan
    {
        double _commitment;
        private DateTime? _expiry;
        IList<Payment> _payments = new List<Payment>();
        private DateTime? _today;
        private DateTime _start;
        private double _riskRating;
        private double _unusedPercentage;

        public Loan(double commitment,
                    DateTime start,
                    DateTime? expiry,
                    int riskRating)
        {
            this._expiry = expiry;
            this._commitment = commitment;
            this._today = null;
            this._start = start;
            this._riskRating = riskRating;
            this._unusedPercentage = 1.0;
        }

        public static Loan NewTermLoan(double commitment, DateTime start, DateTime maturity, int riskRating)
        {
            return new Loan(commitment,  start, null,riskRating);
        }

        public static Loan NewRevolver(double commitment, DateTime start, DateTime expiry, int riskRating)
        {
            return new Loan(commitment,  start, expiry, riskRating);
        }

        public static Loan NewAdvisedLine(double commitment, DateTime start, DateTime expiry, int riskRating)
        {
            if (riskRating > 3) return null;
            Loan advisedLine = new Loan(commitment, start, expiry,riskRating);
            advisedLine.SetUnusedPercentage(0.1);
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

        public void SetUnusedPercentage(double unusedPercentage)
        {
            _unusedPercentage = unusedPercentage;
        }
    }
}