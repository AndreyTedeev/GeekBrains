using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace AndreyTedeev.Part1Lesson3
{
    /// <summary>
    /// Дописать класс Complex, добавив методы вычитания и произведения чисел.
    /// </summary>
    class ComplexClass
    {
        public double Im { get; set; }
        public double Re { get; set; }

        public ComplexClass()
        {
            Im = 0;
            Re = 0;
        }

        public ComplexClass(double im, double re)
        {
            Im = im;
            Re = re;
        }

        public ComplexClass Plus(ComplexClass x)
        {
            return new ComplexClass(Im + x.Im, Re + x.Re);
        }

        public ComplexClass Minus(ComplexClass x)
        {
            return new ComplexClass(Im - x.Im, Re - x.Re);
        }

        public ComplexClass Multi(ComplexClass x)
        {
            return new ComplexClass
            {
                Im = Re * x.Im + Im * x.Re,
                Re = Re * x.Re - Im * x.Im
            };
        }

        public override string ToString()
        {
            return Re + "+" + Im + "i";
        }
    }
}
