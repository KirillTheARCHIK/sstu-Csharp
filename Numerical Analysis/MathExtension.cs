using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numerical_Analysis
{
    class MathExtension
    {
    }

    public class MyMath
    {
        public static long Fact(int n)
        {
            if (n<0)
            {
                throw new ArithmeticException();
            }
            if (n<=1)
            {
                return 1;
            }
            return Fact(n - 1)*n;
        }
    }
}
