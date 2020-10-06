using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreyTedeev.Part1Lesson2
{
    /// <summary>
    /// 5. а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает,
    ///	   нужно ли человеку похудеть, набрать вес или всё в норме.
    ///	   б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
    /// </summary>
    class Task5 : IAbstractTask
    {

        /// <summary>
        /// Индекс массы тела Соответствие между массой человека и его ростом
        /// 16 и менее  Выраженный дефицит массы тела
        /// 16—18,5	Недостаточная(дефицит) масса тела
        /// 18,5—25	Норма
        /// 25—30	Избыточная масса тела(предожирение)
        /// 30—35	Ожирение
        /// 35—40	Ожирение резкое
        /// 40 и более  Очень резкое ожирение
        /// </summary>
        static class BMI
        {
            public static double SeverelyUnderweight = 16D;
            public static double Underweight = 18.5D;
            public static double Normal = 25D;
            public static double Overweight = 30D;
            public static double ObeseModerately = 35D;
            public static double ObeseSeverely = 40D;
            public static double ObeseVerySeverely = Double.MaxValue;
        }

        public void Run()
        {
            Console.WriteLine("5. а) Рассчет индекса массы тела. б) Рекомендации.");

            double weight = Util.AskDoubleForever("Введите массу тела в килограммах : ");
            double height = Util.AskDoubleForever("Введите рост в сантиметрах : ") / 100;
            double bmi = CalcBMI(weight, height);

            Console.Write($"а) Индекс Массы Тела : {bmi:##.##} = ");
            if (bmi < BMI.SeverelyUnderweight)
                Console.WriteLine("Выраженный дефицит массы тела");
            else if (bmi < BMI.Underweight)
                Console.WriteLine("Недостаточная(дефицит) масса тела");
            else if (bmi < BMI.Normal)
                Console.WriteLine("Норма");
            else if (bmi < BMI.Overweight)
                Console.WriteLine("Избыточная масса тела (предожирение)");
            else if (bmi < BMI.ObeseModerately)
                Console.WriteLine("Ожирение (1 степени)");
            else if (bmi < BMI.ObeseSeverely)
                Console.WriteLine("Ожирение резкое (2 степени)");
            else
                Console.WriteLine("Очень резкое ожирение (3 степени)");

            double recomendation = CalcRecomendation(weight, height);
            if (recomendation < 0 )
                Console.WriteLine($"б) Рекомендуем сбросить {-recomendation:###.##} кг.");
            else if (recomendation > 0)
                Console.WriteLine($"б) Рекомендуем набрать {recomendation:###.##} кг.");
            else
                Console.WriteLine("б) Показатель ИМТ в норме.");

            Console.WriteLine();
        }

        /// <summary>
        /// Рассчет Индекса Массы Тела 
        /// </summary>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private double CalcBMI(double weight, double height)
        {
            return weight / (height * height);
        }

        /// <summary>
        /// Рассчет рекомендации набора или снижения веса
        /// </summary>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private double CalcRecomendation(double weight, double height)
        {
            double w = weight;
            while (CalcBMI(w, height) < BMI.Underweight)
            {
                w++;
            }
            while (CalcBMI(w, height) > BMI.Normal)
            {
                w--;
            }
            return w - weight;
        }
    }
}
