using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{

    /// <summary>
    /// 2.	*В некой директории лежат файлы. По структуре они содержат 3 числа, разделенные пробелами. 
    /// 	Первое число — целое, обозначает действие, 1 — умножение и 2 — деление, остальные два — числа с плавающей точкой.
    ///     Написать многопоточное приложение, выполняющее вышеуказанные действия над числами и сохраняющее результат в файл result.dat.
    ///     Количество файлов в директории заведомо много.
    /// </summary>
    public class Part2
    {

        private const string DIR_NAME = "data";

        private struct Rec
        {
            public int Operation;
            public double Value1;
            public double Value2;

            public override string ToString() => $"{Operation} {Value1:###0.00} {Value2:###0.00}";

            public static Rec Parse(string s)
            {
                string[] fields = s.Split(' ');
                if (fields.Length != 3)
                    throw new ArgumentException("Wrong format");
                return new Rec
                {
                    Operation = int.Parse(fields[0]),
                    Value1 = double.Parse(fields[1]),
                    Value2 = double.Parse(fields[2])
                };
            }

            public double ProcessOperation()
            {
                return Operation switch
                {
                    1 => Value1 * Value2,
                    2 => Value1 / Value2,
                    _ => throw new Exception("Wrong Operation"),
                };
            }
        }

        public static async Task Run()
        {
            Console.Write("Generation of test data : ");
            await GenerateData();
            Console.WriteLine("Done");

            Console.Write("Processing test data : ");
            double result = await ProcessData();
            Console.WriteLine("Done");

            Console.WriteLine($"Result is {result:0.00}");
        }

        private static async Task<double> ProcessData()
        {
            if (!Directory.Exists(DIR_NAME))
                throw new Exception($"Directory {DIR_NAME} not found");

            double result = default;

            foreach (string fileName in Directory.GetFiles(DIR_NAME, "f*.txt"))
            {
                using (StreamReader reader = File.OpenText(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        result += Rec.Parse(await reader.ReadLineAsync()).ProcessOperation();
                    }
                }
            }
            return result;
        }

        private static async Task GenerateData()
        {
            Random random = new Random();
            int numFiles = 10;
            int numOps = 10;
            Rec rec;

            if (!Directory.Exists(DIR_NAME))
                Directory.CreateDirectory(DIR_NAME);

            for (int i = 0; i < numFiles; i++)
            {
                using (FileStream stream = File.Create($"{DIR_NAME}\\f{i:00}.txt"))
                {
                    for (int j = 0; j < numOps; j++)
                    {
                        rec = new Rec
                        {
                            Operation = (random.Next(1, 100) % 2 == 0) ? 1 : 2,
                            Value1 = random.Next(100, 10000) / 100.00,
                            Value2 = random.Next(100, 10000) / 100.00
                        };
                        await stream.WriteAsync(Encoding.ASCII.GetBytes(rec.ToString() + '\n'));
                    }
                }
            }
        }

    }
}
