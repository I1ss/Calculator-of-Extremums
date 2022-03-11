using System;

namespace func
{
    public class CalculatorExtremum
    {
        private double search_golden_section_x1(double a, double b, double fi)
        {
            return (b - ((b - a) / fi));
        }
        private double search_golden_section_x2(double a, double b, double fi)
        {
            return (a + ((b - a) / fi));
        }
        /// <summary>
        /// Поиск экстремума методом золотого сечения.
        /// </summary>
        /// <param name="func">Указатель на функцию, для которой ищется экстремум.</param>
        /// <param name="a">Крайняя левая граница по оси х.</param>
        /// <param name="b">Крайняя правая граница по оси у.</param>
        /// <param name="eps">Заданная точность вычислений.</param>
        /// <param name="fi">Число "фи".</param>
        /// <returns></returns>
        public double calc_golden_section(Func<double, double> func, double a, double b, double eps, double fi, string extr = "default")
        {
            double ans = 0;
            double x1 = search_golden_section_x1(a, b, fi);
            double x2 = search_golden_section_x2(a, b, fi);
            double y1 = func(x1);
            double y2 = func(x2);
            string answer = extr;
            if (extr == "default")
            {
                Console.WriteLine("What we should search? MAX or MIN?");
                answer = Console.ReadLine();
            }
            if (answer == "MAX")
            {
                while (Math.Abs(b - a) >= eps)
                {
                    if (y2 > y1)
                    {
                        a = x1;
                    }
                    else
                    {
                        b = x2;
                    }
                    x1 = search_golden_section_x1(a, b, fi);
                    x2 = search_golden_section_x2(a, b, fi);
                    y1 = func(x1);
                    y2 = func(x2);
                }
                ans = (a + b) / 2;
            }
            else if (answer == "MIN")
            {
                while (Math.Abs(b - a) >= eps)
                {
                    if (y1 >= y2)
                    {
                        a = x1;
                    }
                    else
                    {
                        b = x2;
                    }
                    x1 = search_golden_section_x1(a, b, fi);
                    x2 = search_golden_section_x2(a, b, fi);
                    y1 = func(x1);
                    y2 = func(x2);
                }
                ans = (a + b) / 2;
            }
            else
            {
                Console.WriteLine("Incorrect value. Abort.");
                return 0;
            }
            return ans;
        }
        /// <summary>
        /// Поиск экстремума методом дихотомии.
        /// </summary>
        /// <param name="func">Указатель на функцию, для которой ищется экстремум.</param>
        /// <param name="a">Крайняя левая граница по оси х.</param>
        /// <param name="b">Крайняя правая граница по оси у.</param>
        /// <param name="eps">Заданная точность вычислений.</param>
        /// <param name="fi">Число "фи".</param>
        /// <returns></returns>
        public double calc_dichotomy(Func<double, double> func, double a, double b, double eps, double fi)
        {
            double x1 = search_golden_section_x1(a, b, fi);
            double x2 = search_golden_section_x2(a, b, fi);
            double y1 = func(x1);
            double y2 = func(x2);
            Console.WriteLine("What we should search? MAX or MIN?");
            string answer = Console.ReadLine();
            if (answer == "MIN")
            {
                while (Math.Abs(b - a) > (2 * eps))
                {
                    x1 = ((a + b) / 2) - eps;
                    x2 = ((a + b) / 2) + eps;
                    y1 = func(x1);
                    y2 = func(x2);
                    if (y1 < y2)
                    {
                        b = x2;
                    }
                    else
                    {
                        a = x1;
                    }
                }
            }
            else if (answer == "MAX")
            {
                while (Math.Abs(b - a) > (2 * eps))
                {
                    x1 = ((a + b) / 2) - eps;
                    x2 = ((a + b) / 2) + eps;
                    y1 = func(x1);
                    y2 = func(x2);
                    if (y1 < y2)
                    {
                        a = x1;
                    }
                    else
                    {
                        b = x2;
                    }
                }
            }
            return a;
        }
    }
}
