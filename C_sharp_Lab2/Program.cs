using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Lab2
{
    internal class Program
    {

        static double exactValue(double value)
        {
            return 1.0 / Math.Sqrt(1.0 - value * value);
        }

        static double tailorValue(double value, double eps)
        {
            double term = 1;
            double sum = term;
            int n = 1;

            while (Math.Abs(term) > eps)
            {
                term *= (2 * n - 1.0) * value * value / (2 * n);
                sum += term;
                n++;
            }
            return sum;

        }

        static void Main(string[] args)
        {
            Console.Write("Введите начальное значение X0 (-1<X0<1):");
            double X0 = double.Parse(Console.ReadLine());

            Console.Write("Введите конечное значение Xn (-1<Xn<1):");
            double Xn = double.Parse(Console.ReadLine());

            Console.Write("Введите шаг h:");
            double h = double.Parse(Console.ReadLine());

            Console.Write("Введите точность eps:");
            double eps = double.Parse(Console.ReadLine());

            string xRow = $"{"x:",-20}";
            string calculatedRow = "f(x) вычисленное: ";
            string exactRow = "f(x) по формуле:  ";

            int counter = 0;
            const int valuesPerRow = 5;
            double tailorVal = 0;
            double exactVal = 0;
            double lastX = X0;

            for (double x = X0; x < Xn; x += h)
            {
                tailorVal = tailorValue(x, eps);
                exactVal = exactValue(x);
                lastX = x;


                xRow += $"{x,-14:F5} ";
                calculatedRow += $"{tailorVal,14:F10} ";
                exactRow += $"{exactVal,14:F10} ";
                counter++;

                if (counter % valuesPerRow == 0)
                {
                    Console.WriteLine(xRow);
                    Console.WriteLine(calculatedRow);
                    Console.WriteLine(exactRow);
                    Console.WriteLine();

                    xRow = $"{"x:",-20}";
                    calculatedRow = "f(x) вычисленное: ";
                    exactRow = "f(x) по формуле:  ";
                }
            }

            if (lastX+eps < Xn)
            {
                tailorVal = tailorValue(Xn, eps);
                exactVal = exactValue(Xn);

                // Добавляем последние значения
                xRow += $"{Xn,-14:F5} ";
                calculatedRow += $"{tailorVal,14:F10} ";
                exactRow += $"{exactVal,14:F10} ";
                counter++;
            }

            if (counter % valuesPerRow != 0)
            {
                Console.WriteLine(xRow);
                Console.WriteLine(calculatedRow);
                Console.WriteLine(exactRow);
            }

            Console.ReadKey();
        }
    }
}




