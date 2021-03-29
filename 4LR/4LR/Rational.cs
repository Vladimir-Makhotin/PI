using System;
using System.Collections.Generic;
using System.Text;

namespace _4LR
{
    class Rational
    {
        private int a;
        private int b;
        private int sign;
        public Rational(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("знаменатель не может быть равне нулю");
            }
            this.a = Math.Abs(a);
            this.b = Math.Abs(b);
            if (a * b < 0)
                this.sign = -1;
            else
                this.sign = 1;
        }
        public Rational(int a)
        {
            this.a = a;
            this.b = 1;
            if (a * b < 0)
                this.sign = -1;
            else
                this.sign = 1;
        }
        public int number(Rational num, int c)
        {
            int a, b;
            a = num.a; b = num.b;
            if (c == 1)
                return a*num.sign;
            else return b;
        }
        public override string ToString()
        {
            if (this.a == 0)
                return "0";
            string result;
            if (this.sign < 0)
                result = "-";
            else
                result = "";
            if (this.a == this.b)
                return result + "1";
            if (this.b == 1)
                return result + this.a;
            return result + this.a + "/" + this.b;
        }
        private static int GreattestDivisor(int a, int b)
        {
            while (b != 0)
            {
                int t = b; b = a % b; a = t;
            }
            return a;
        }
        private static int LeastMultiple(int a, int b)
        {
            return a * b / GreattestDivisor(a, b);
        }
        private static Rational performOperation(Rational a, Rational b, Func<int, int, int> operation)
        {
            int LM = LeastMultiple(a.b, b.b);
            int additionalMiltiplierFirst = LM / a.b;
            int additionalMiltiplierSecond = LM / b.b;
            int result = operation(a.a * additionalMiltiplierFirst * a.sign, b.a * additionalMiltiplierSecond * b.sign);
            return new Rational(result, a.b * additionalMiltiplierFirst);
        }
        private Rational GetReverse()
        {
            return new Rational(this.b * this.sign, this.a);
        }
        public static Rational operator +(Rational a, Rational b)
        {
            return performOperation(a, b, (int x, int y) => x + y);
        }
        public static Rational operator +(Rational a, int b)
        {
            return a + new Rational(b);
        }
        public static Rational operator +(int a, Rational b)
        {
            return b + a;
        }
        public static Rational operator -(Rational a, Rational b)
        {
            return performOperation(a, b, (int x, int y) => x - y);
        }
        public static Rational operator -(Rational a, int b)
        {
            return a - new Rational(b);
        }
        public static Rational operator -(int a, Rational b)
        {
            return b - a;
        }
        public static Rational operator *(Rational a, Rational b)
        {
            return new Rational(a.a * a.sign * b.a * b.sign, a.b * b.b);
        }
        public static Rational operator *(Rational a, int b)
        {
            return a * new Rational(b);
        }
        public static Rational operator *(int a, Rational b)
        {
            return b * a;
        }
        public static Rational operator /(Rational a, Rational b)
        {
            return a * b.GetReverse();
        }
        public static Rational operator /(Rational a, int b)
        {
            return a / new Rational(b);
        }
        public static Rational operator /(int a, Rational b)
        {
            return new Rational(a) / b;
        }
        public bool Equals(Rational that)
        {
            Rational a = this.Reduce();
            Rational b = that.Reduce();
            return a.a == b.a && a.b == b.b && a.sign == b.sign;
        }
        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is Rational)
            {
                result = this.Equals(obj as Rational);
            }
            return result;
        }
        public static bool operator ==(Rational a, Rational b)
        {
            Object aAsObj = a as Object;
            Object bAsObj = b as Object;
            if (aAsObj == null || bAsObj == null)
            {
                return aAsObj == bAsObj;
            }
            return a.Equals(b);
        }
        public static bool operator ==(Rational a, int b)
        {
            return a == new Rational(b);
        }
        public static bool operator ==(int a, Rational b)
        {
            return new Rational(a) == b;
        }
        public static bool operator !=(Rational a, Rational b)
        {
            return !(a == b);
        }
        public static bool operator !=(Rational a, int b)
        {
            return a != new Rational(b);
        }
        public static bool operator !=(int a, Rational b)
        {
            return new Rational(a) != b;
        }
        private int CompareTo(Rational that)
        {
            if (this.Equals(that))
            {
                return 0;
            }
            Rational a = this.Reduce();
            Rational b = that.Reduce();
            if (a.a * a.sign * b.b > b.a * b.sign * a.b)
            {
                return 1;
            }
            return -1;
        }
        public static bool operator >(Rational a, Rational b)
        {
            return a.CompareTo(b) > 0;
        }
        public static bool operator >(Rational a, int b)
        {
            return a > new Rational(b);
        }
        public static bool operator >(int a, Rational b)
        {
            return new Rational(a) > b;
        }
        public static bool operator <(Rational a, Rational b)
        {
            return a.CompareTo(b) < 0;
        }
        public static bool operator <(Rational a, int b)
        {
            return a < new Rational(b);
        }
        public static bool operator <(int a, Rational b)
        {
            return new Rational(a) < b;
        }
        public static bool operator >=(Rational a, Rational b)
        {
            return a.CompareTo(b) >= 0;
        }
        public static bool operator >=(Rational a, int b)
        {
            return a >= new Rational(b);
        }
        public static bool operator >=(int a, Rational b)
        {
            return new Rational(a) >= b;
        }
        public static bool operator <=(Rational a, Rational b)
        {
            return a.CompareTo(b) <= 0;
        }
        public static bool operator <=(Rational a, int b)
        {
            return a <= new Rational(b);
        }
        public static bool operator <=(int a, Rational b)
        {
            return new Rational(a) <= b;
        }
        public Rational Reduce()
        {
            Rational result = this;
            int greatestCommonDivisor = GreattestDivisor(this.a, this.b);
            result.a /= greatestCommonDivisor;
            result.b /= greatestCommonDivisor;
            return result;
        }
    }
}
