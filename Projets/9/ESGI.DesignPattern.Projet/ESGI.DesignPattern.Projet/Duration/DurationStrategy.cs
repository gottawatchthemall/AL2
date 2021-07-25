using System;

namespace ESGI.DesignPattern.Projet
{
    public abstract class DurationStrategy
    {
    private long MILLIS_PER_DAY = 86400000;
    private long DAYS_PER_YEAR = 365;
    
    public abstract double Get(Loan loan);
    
    protected double YearsTo(DateTime? endDate, Loan loan)
    {
        DateTime? beginDate = loan.GetStart();
        return (double)((endDate?.Ticks - beginDate?.Ticks) / MILLIS_PER_DAY / DAYS_PER_YEAR);
    }
    }
}