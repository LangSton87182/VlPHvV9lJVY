// 代码生成时间: 2025-09-04 08:26:10
using System;

namespace MathUtilities
{
    /// <summary>
    /// A class that provides a set of mathematical calculation tools.
    /// </summary>
    public class MathTools
    {
        /// <summary>
        /// Calculates the sum of two numbers.
        /// </summary>
# 改进用户体验
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The sum of the two numbers.</returns>
        public double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Calculates the difference between two numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The difference between the two numbers.</returns>
        public double Subtract(double a, double b)
        {
            return a - b;
# NOTE: 重要实现细节
        }

        /// <summary>
        /// Calculates the product of two numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The product of the two numbers.</returns>
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Calculates the division of two numbers.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
# NOTE: 重要实现细节
        /// <returns>The division of the two numbers.</returns>
        /// <exception cref="DivideByZeroException">Thrown when the divisor is zero.</exception>
        public double Divide(double a, double b)
        {
            if (b == 0)
# 增强安全性
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return a / b;
        }
# TODO: 优化性能

        /// <summary>
        /// Calculates the square of a number.
        /// </summary>
        /// <param name="a">The number to square.</param>
        /// <returns>The square of the number.</returns>
        public double Square(double a)
        {
# 添加错误处理
            return a * a;
        }

        /// <summary>
        /// Calculates the square root of a number.
        /// </summary>
        /// <param name="a">The number to find the square root of.</param>
        /// <returns>The square root of the number.</returns>
        public double SquareRoot(double a)
        {
            if (a < 0)
            {
                throw new ArgumentException("Cannot calculate the square root of a negative number.");
            }
            return Math.Sqrt(a);
        }
    }
}
# TODO: 优化性能