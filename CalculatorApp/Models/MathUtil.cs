using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Models
{
    public static class MathUtil
    {
        // Adds two numbers
        public static double Add(double a, double b) => a + b;

        // Subtracts one number from another
        public static double Subtract(double a, double b) => a - b;

        // Multiplies two numbers
        public static double Multiply(double a, double b) => a * b;

        // Divides one number by another
        public static double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }

        // Calculates the percentage of a number
        public static double Percentage(double a) => a / 100;
    }
}
