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
            Console.Write("Введите начальное значение X0:");
            double X0 = double.Parse(Console.ReadLine());

            Console.Write("Введите конечное значение Xn:");
            double Xn = double.Parse(Console.ReadLine());

            Console.Write("Введите шаг h:");
            double h = double.Parse(Console.ReadLine());

            Console.Write("Введите шаг eps:");
            double eps = double.Parse(Console.ReadLine());

            Console.WriteLine($"\n{"x",18} | {"f(x) вычисленное",16} | {"f(x) по формуле",16} |");
            Console.WriteLine("-----------------------------------------------");

            for (double x = X0; x <= Xn; x += h)
            {
                double tailorVal = tailorValue(x, eps);

                double exactVal = exactValue(x);

                Console.WriteLine($"| {x,16:F10} | {tailorVal,16:F10} | {exactVal,16:F10} |");
            }


        }
    }
}
