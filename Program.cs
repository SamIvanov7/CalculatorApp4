using System;

namespace CalculatorApp4

{   /// Перелік арифметичних операцій, які можна виконати.
    public enum ArithmeticOperation
    {
        Add,        // Додавання
        Subtract,   // Віднімання
        Multiply,   // Множення
        Divide      // Ділення
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter first number: ");
                double number1 = double.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");
                double number2 = double.Parse(Console.ReadLine());

                Console.Write("Enter an arithmetic operation (+, -, *, /): ");
                ArithmeticOperation operation = ParseOperation(Console.ReadLine());

                double result = PerformCalculation(number1, number2, operation);

                Console.WriteLine($"Result: {result}");
            }
            // Ловимо помилки, що можуть виникнути під час вводу даних або обчислень
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid number format.");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Division by zero.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        
        /// Парсинг рядка у відповідну арифметичну операцію.
        /// <param name="input">Рядок, що містить символ арифметичної операції.</param>
        /// <returns>Об'єкт переліку ArithmeticOperation, що відповідає введеній операції.</returns>
        
        static ArithmeticOperation ParseOperation(string input)
        {
            return input switch
            {
                "+" => ArithmeticOperation.Add,
                "-" => ArithmeticOperation.Subtract,
                "*" => ArithmeticOperation.Multiply,
                "/" => ArithmeticOperation.Divide,
                _ => throw new ArgumentException("Invalid arithmetic operation.")
            };
        }


        /// Виконання обраної арифметичної операції з двома числами.
        /// <param name="number1">Перше число.</param>
        /// <param name="number2">Друге число.</param>
        /// <param name="operation">Арифметична операція, яку необхідно виконати.</param>
        /// <returns>Результат обчислення.</returns>
        static double PerformCalculation(double number1, double number2, ArithmeticOperation operation)
        {
            return operation switch
            {
                ArithmeticOperation.Add => number1 + number2,
                ArithmeticOperation.Subtract => number1 - number2,
                ArithmeticOperation.Multiply => number1 * number2,
                ArithmeticOperation.Divide when number2 != 0 => number1 / number2,
                ArithmeticOperation.Divide => throw new DivideByZeroException(),
                _ => throw new ArgumentException("Invalid arithmetic operation.")
            };
        }
    }
}
