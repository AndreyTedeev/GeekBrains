using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson1
{

    public class Person
    {

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public float Age { get; set; }
        
        public float Height { get; set; }
        
        public float Weight { get; set; }

        /*
         * returns : индекс массы тела (ИМТ) (Body Mass Index)
         */
        public float BMI {
            get { return Weight / (Height * Height); }
        }

        /*
         * prints Person to console
         *  В результате вся информация выводится в одну строчку:
         *      а) используя склеивание;
         *      б) используя форматированный вывод;
         *      в) используя вывод со знаком $.
         */
        public void Print() {
            Console.Write(FirstName + " " + LastName + ","); // а
            Console.Write("возраст: {0:F0}, рост: {1:F2}, вес: {2:F2},", Age, Height, Weight); // б
            Console.WriteLine($" ИМТ: {BMI:####.#}"); // в
        }

    }
}
