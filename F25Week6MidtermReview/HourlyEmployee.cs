using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F25Week6MidtermReview
{
    public class HourlyEmployee : Employee
    {
        public int Hours { get; set; }
        public double Wage { get; set; }

        public HourlyEmployee(string name, int hours, double wage) : base(name)
        {
            Hours = hours;
            Wage = wage;
        }

        public override double GrossEarnings()
        {
            if (Hours <= 40)
                return Hours * Wage;
            else
                return (40 * Wage) + (Hours - 40) * Wage * 1.5;
        }
    }
}
