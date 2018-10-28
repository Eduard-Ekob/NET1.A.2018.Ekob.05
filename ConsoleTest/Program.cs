using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  PolynomOperations;

namespace ConsoleTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            double[] p2 = new double[] { 1, 0, 2 };
            double[] p1 = new double[] {2,7 };
            //double[] p2 = new double[] {1,8};
            var poly1 = new Polynominal(p1);
            var poly2 = new Polynominal(p2);
            //var p3 = poly2 * poly1;
            Console.WriteLine(poly2.ToString());
            //Console.WriteLine(p3=(poly2+poly1).ToString());
            //Console.WriteLine(p3.ToString());
            //Array.ForEach(p3, x => Console.Write(x + " "));

            Console.ReadLine();

        }

    }
}
