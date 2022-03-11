using System;

namespace func
{
    public class Program
    {
        static double search_value_func(double x) { return x * x; }
        static void Main(string[] args)
        {
            const double EPS = 0.001;
            const double PHI = 1.618;
            double a = 0;
            double b = 3;
            Func<double, double> func = search_value_func;
            Console.Write("Our extremum: ");
            CalculatorExtremum calc = new CalculatorExtremum();
            Console.WriteLine(calc.calc_golden_section(func, a, b, EPS, PHI));
            Console.WriteLine(calc.calc_dichotomy(func, a, b, EPS, PHI));
        }
    }
}
