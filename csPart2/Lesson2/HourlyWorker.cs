using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    class HourlyWorker : AbstractWorker
    {
        public HourlyWorker(string name, double hourlyRate) : base(name, hourlyRate)
        {
        }

        public override double Salary { get => 20.8D * 8D * HourlyRate; }

    }
}
