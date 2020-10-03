using System;
using System.Collections.Generic;
using System.Text;

namespace AndreyTedeev.Part1Lesson3
{
    /// <summary>
    /// 3. *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. 
    /// Предусмотреть методы сложения, вычитания, умножения и деления дробей.
    /// Написать программу, демонстрирующую все разработанные элементы класса.
    ///
    /// * Добавить свойства типа int для доступа к числителю и знаменателю;
    /// * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
    /// ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
    /// *** Добавить упрощение дробей.
    /// </summary>
    class Fraction
    {

        private int _denominator = 1;

        /// <summary>
        /// Знаменатель default 1
        /// </summary>
        public int Denominator
        {

            get { return _denominator; }

            set
            {
                if (value == 0)
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                else
                    _denominator = value;
            }
        }

        /// <summary>
        /// Числитель default 1
        /// </summary>
        public int Numerator { get; set; } = 1;

        /// <summary>
        ///  Конструктор
        /// </summary>
        public Fraction()
        {
        }

        /// <summary>
        ///  Конструктор
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        public Fraction(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        /// <summary>
        /// Реультат в десятичном виде
        /// </summary>
        public double AsDouble
        {
            get
            {
                return (double)Numerator / (double)Denominator;
            }
        }

        /// <summary>
        /// Сокращение дроби
        /// </summary>
        /// <returns> true если дробь сократилась</returns>
        public bool Reduce() 
        {
            // Метод в библиотеке Library
            int nod = AndreyTedeev.Util.NOD(Numerator, Denominator);
            Numerator = Numerator / nod;
            Denominator = Denominator / nod;
            return nod > 1;
        }

        public Fraction Plus(Fraction f)
        {
            int n, d;
            if (this.Denominator == f.Denominator)
            {
                n = this.Numerator + f.Numerator;
                d = this.Numerator;
            }
            else
            {
                // Метод в библиотеке Library
                d = AndreyTedeev.Util.NOK(this.Denominator, f.Denominator);
                n = d / this.Denominator * this.Numerator +  d / f.Denominator * f.Numerator;
            }
            
            return new Fraction(n, d);
        }

        public Fraction Minus(Fraction f)
        {
            int n, d;
            if (this.Denominator == f.Denominator)
            {
                n = this.Numerator - f.Numerator;
                d = this.Numerator;
            }
            else
            {
                // Метод в библиотеке Library
                d = AndreyTedeev.Util.NOK(this.Denominator, f.Denominator);
                n = d / this.Denominator * this.Numerator - d / f.Denominator * f.Numerator;
            }

            return new Fraction(n, d);
        }

        public Fraction Multi(Fraction f)
        {
            return new Fraction
            {
                Numerator = this.Numerator * f.Numerator,
                Denominator = this.Denominator * f.Denominator
            };
        }

        public Fraction Divide(Fraction f)
        {
            return new Fraction
            {
                Numerator = this.Numerator * f.Denominator,
                Denominator = this.Denominator * f.Numerator
            };
        }

        public override string ToString() {
            return String.Format($"{Numerator} / {Denominator} [{AsDouble:0.####}]");
        }

    }
}
