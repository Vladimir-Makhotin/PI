using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _5LR
{
    class Equation
    {
        private double x0;
        private double x1;
        private double e;
        public Equation(double a, double b)
        {
            this.x0 = a;
            this.x1 = b;
            this.e = 0.001;
        }
        public double function1(double x)
        {
            return 1 - x1 * Math.Cos(x);
        }
        public double function2(double x)
        {
            return Math.Pow(x, 3) + 2 * Math.Pow(x, 2) - 3 * x - 2;
        }
        public double deltaYfunc1(double x)
        {
            return -Math.Cos(x) + x1 * Math.Sin(x);
        }
        public double deltaYfunc2(double x)
        {
            return 3 * Math.Pow(x, 2) + 4 * x - 3;
        }
        public double Newtonfunc1()
        {
            double result;
            if (function1(this.x0) * deltaYfunc1(this.x0) > 0)
            {
                result = this.x0;
                result = result - function1(result) / deltaYfunc1(result);
            }
            else
            {
                result = this.x1;
                result = result - function1(result) / deltaYfunc1(result);
            }
            while(Math.Abs(function1(result))<e*Math.Abs(deltaYfunc1(result)))
            {
                result = result - function1(result) / deltaYfunc1(result);
            }
            return result;
        }
        public double Newtonfunct2()
        {
            double result;
            if (function2(this.x0) * deltaYfunc2(this.x0) > 0)
            {
                result = this.x0;
                result = result - function2(result) / deltaYfunc2(result);
            }
            else
            {
                result = this.x1;
                result = result - function2(result) / deltaYfunc2(result);
            }
            while (Math.Abs(function2(result)) < e * Math.Abs(deltaYfunc2(result)))
            {
                result = result - function2(result) / deltaYfunc2(result);
            }
            return result;
        }
        public double HalfDivisionfunct1()
        {
            double a = this.x0; double b = this.x1; 
            double c = (a + b) / 2;
            while ((Math.Abs(b-a)>this.e)&&(function1(c)!=0))
            {
                if (function1(a) * function1(c) < 0)
                    b = c;
                else
                    a = c;
                c = (a + b) / 2;
            }
            return c;
        }
        public double HalfDivisionfunct2()
        {
            double a = this.x0; double b = this.x1;
            double c = (a + b) / 2;
            while ((Math.Abs(b - a) > this.e) && (function2(c) != 0))
            {
                if (function2(a) * function2(c) < 0)
                    b = c;
                else
                    a = c;
                c = (a + b) / 2;
            }
            return c;
        }
        public double firstvalue()
        {
            return this.x0;
        }
        public double seconvalue()
        {
            return this.x1;
        }
    }
}
