// 代码生成时间: 2025-08-01 12:00:25
using System;
using Xamarin.Forms;

namespace MathCalculatorApp
{
    public partial class MainPage : ContentPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        // Method to add numbers
        private double Add(double number1, double number2)
        {
            try
            {
                return number1 + number2;
            }
            catch (Exception ex)
            {
                // Log the exception and return a default value
                Console.WriteLine($"Error occurred: {ex.Message}");
                return 0;
            }
        }

        // Method to subtract numbers
        private double Subtract(double number1, double number2)
        {
            try
            {
                return number1 - number2;
            }
            catch (Exception ex)
            {
                // Log the exception and return a default value
                Console.WriteLine($"Error occurred: {ex.Message}");
                return 0;
            }
        }

        // Method to multiply numbers
        private double Multiply(double number1, double number2)
        {
            try
            {
                return number1 * number2;
            }
            catch (Exception ex)
            {
                // Log the exception and return a default value
                Console.WriteLine($"Error occurred: {ex.Message}");
                return 0;
            }
        }

        // Method to divide numbers with error handling for division by zero
        private double Divide(double number1, double number2)
        {
            try
            {
                if (number2 == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero.");
                }
                return number1 / number2;
            }
            catch (DivideByZeroException ex)
            {
                // Log the specific division by zero exception and return a default value
                Console.WriteLine($"Error occurred: {ex.Message}");
                return 0;
            }
            catch (Exception ex)
            {
                // Log any other exceptions and return a default value
                Console.WriteLine($"Error occurred: {ex.Message}");
                return 0;
            }
        }

        // Event handler for the add button
        private void OnAddClicked(object sender, EventArgs e)
        {
            double result = Add(double.Parse(entryNumber1.Text), double.Parse(entryNumber2.Text));
            labelResult.Text = $"Result: {result}";
        }

        // Event handler for the subtract button
        private void OnSubtractClicked(object sender, EventArgs e)
        {
            double result = Subtract(double.Parse(entryNumber1.Text), double.Parse(entryNumber2.Text));
            labelResult.Text = $"Result: {result}";
        }

        // Event handler for the multiply button
        private void OnMultiplyClicked(object sender, EventArgs e)
        {
            double result = Multiply(double.Parse(entryNumber1.Text), double.Parse(entryNumber2.Text));
            labelResult.Text = $"Result: {result}";
        }

        // Event handler for the divide button
        private void OnDivideClicked(object sender, EventArgs e)
        {
            double result = Divide(double.Parse(entryNumber1.Text), double.Parse(entryNumber2.Text));
            labelResult.Text = $"Result: {result}";
        }
    }
}