using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    class MonthlyWorker : AbstractWorker
    {
        double _salary;

        public MonthlyWorker(string name, double salary) : base(name)
        {
            _salary = salary;
        }

        public override double Salary { get => _salary; }
    }
}
