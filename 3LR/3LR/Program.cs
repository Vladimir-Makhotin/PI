using System;

namespace _3LR
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational a = new Rational(4, 5);
            Rational b = new Rational(5);
            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
            Rational t = a + a;
            Console.WriteLine((a+a).ToString());
            Console.WriteLine((a+b).ToString());
            Console.WriteLine((t-a).ToString());
            Console.WriteLine((t-b).ToString());
            Console.WriteLine((b-a).ToString());
            Console.WriteLine((a*a).ToString());
            Console.WriteLine((a*b).ToString());
            Console.WriteLine((t/a).ToString());
            Console.WriteLine((t/a).Reduce().ToString());
            Console.WriteLine((a/t).ToString());
            Console.WriteLine((a/t).Reduce().ToString());
            Console.WriteLine((a/a).ToString());
            Console.WriteLine(a == a);
            Console.WriteLine(a == b);
            Console.WriteLine(b == a);
            Console.WriteLine(a != a);
            Console.WriteLine(a != b);
            Console.WriteLine(b != a);
            Console.WriteLine(a > a);
            Console.WriteLine(a < a);
            Console.WriteLine(a > b);
            Console.WriteLine(a < b);
            Console.WriteLine(b > a);
            Console.WriteLine(b < a);
            Console.WriteLine(a >= a);
            Console.WriteLine(b >= a);
            Console.WriteLine(a >= b);
            Console.WriteLine(a <= a);
            Console.WriteLine(b <= a);
            Console.WriteLine(a <= b);
        }
    }
}
