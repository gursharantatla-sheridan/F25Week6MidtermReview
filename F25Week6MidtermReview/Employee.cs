using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F25Week6MidtermReview
{
    public abstract class Employee
    {
        public string Name { get; set; }

        public Employee(string name)
        {
            Name = name;
        }

        public abstract double GrossEarnings();

        public double Tax()
        {
            return GrossEarnings() * 0.20;
        }

        public double NetEarnings()
        {
            return GrossEarnings() - Tax();
        }
    }
}
