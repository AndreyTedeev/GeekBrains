using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Lesson2
{
    abstract class AbstractWorker : IComparer<AbstractWorker>, IComparable<AbstractWorker>
    {

        public string Name { get; set; }

        public double HourlyRate { get; set; }

        public abstract double Salary { get;}
        
        public void Print()
        {
            Console.WriteLine($"Name: {Name}, Salary: {Salary:## ###.00}, Class: {this.GetType().Name}");
        }

        public int Compare(AbstractWorker x, AbstractWorker y)
        {
            double d = x.Salary - y.Salary;
            return (d < 0) ? -1 : (d > 0) ? 1 : 0;
        }

        public int CompareTo(AbstractWorker other)
        {
            return this.Compare(this, other);
        }

        public AbstractWorker(string name)
        {
            Name = name;
        }

        public AbstractWorker(string name, double hourlyRate)
        {
            Name = name;
            HourlyRate = hourlyRate;
        }

    }
}
