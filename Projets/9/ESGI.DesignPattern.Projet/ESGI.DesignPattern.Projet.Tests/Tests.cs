using System;
using Xunit;

namespace ESGI.DesignPattern.Projet.Tests
{
    public class Tests
    {
        private readonly double LOAN_AMOUNT = 10000.00;
        private readonly double TWO_DIGIT_PRECISION = 0.001;


        [Fact()]
        public void test_term_loan_same_payments()
        {
            DateTime start = November(20, 2003);

            Loan termLoan = LoanFactory.Create(LoanType.TermLoan, LOAN_AMOUNT, start, null);
            termLoan.Payment(1000.00, November(20, 2004));
            termLoan.Payment(1000.00, November(20, 2005));
            termLoan.Payment(1000.00, November(20, 2006));
            
            Assert.Equal(20027, termLoan.Duration(new DurationStrategyTermLoan()), (int)TWO_DIGIT_PRECISION);
            Assert.Equal(6008100, termLoan.Capital(new CapitalStrategyTermLoan(), new DurationStrategyTermLoan()), (int)TWO_DIGIT_PRECISION);
        }

        [Fact()]
        public void test_revolver_loan_same_payments()
        {
            DateTime start = November(20, 2003);
            DateTime expiry = November(20, 2007);

            Loan revolverLoan = LoanFactory.Create(LoanType.RevolverLoan, LOAN_AMOUNT, start, expiry);
            revolverLoan.Payment(1000.00, November(20, 2004));
            revolverLoan.Payment(1000.00, November(20, 2005));
            revolverLoan.Payment(1000.00, November(20, 2006));

            Assert.Equal(40027, revolverLoan.Duration(new DurationStrategyDefault()), (int)TWO_DIGIT_PRECISION);
            Assert.Equal(4002700, revolverLoan.Capital(new CapitalStrategyRevolver(), new DurationStrategyDefault()), (int)TWO_DIGIT_PRECISION);
        }

        private static DateTime November(int dayOfMonth, int year)
        {
            return new DateTime(year, 11, dayOfMonth);
        }

        [Fact()]
        public void payment_is_constructed_correctly()
        {
            var christmasDay = new DateTime(2010, 12, 25);
            var payment = new Payment(1000.0, christmasDay);

            Assert.Equal(1000, payment.Amount);
            Assert.Equal(christmasDay, payment.Date);

        }

        [Fact()]
        public void test_advised_line_loan_same_payments()
        {
            DateTime start = November(20, 2003);
            DateTime expiry = November(20, 2007);

            Loan advisedLineLoan = LoanFactory.Create(LoanType.AdvisedLineLoan, LOAN_AMOUNT, start, expiry);
            advisedLineLoan.Payment(1000.00, November(20, 2004));
            advisedLineLoan.Payment(1000.00, November(20, 2005));
            advisedLineLoan.Payment(1000.00, November(20, 2006));

            Assert.Equal(40027, advisedLineLoan.Duration(new DurationStrategyDefault()), (int)TWO_DIGIT_PRECISION);
            Assert.Equal(1200810, advisedLineLoan.Capital(new CapitalStrategyAdvisedLine(), new DurationStrategyDefault()), (int)TWO_DIGIT_PRECISION);
        }

    }
}

