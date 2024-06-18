using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите выражение в формате a + b, a - b, a * b, a / b:");
        string input = Console.ReadLine();

        try
        {
            string[] parts = input.Split(' ');
            if (parts.Length != 3)
            {
                Console.WriteLine("Ошибка: Неправильный формат ввода!");
                return;
            }

            double num1, num2;
            bool isNum1Valid = double.TryParse(parts[0], out num1);
            bool isNum2Valid = double.TryParse(parts[2], out num2);
            if (!isNum1Valid || !isNum2Valid)
            {
                Console.WriteLine("Ошибка: Ввод должен быть числом. Проверьте введенные данные.");
                return;
            }

            char op = parts[1][0];
            double result = Calculate(num1, num2, op);
            if (double.IsNaN(result))
            {
                Console.WriteLine("Ошибка: Недопустимая операция.");
            }
            else
            {
                Console.WriteLine("Результат: " + result);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка при обработке ввода: " + ex.Message);
        }
    }

    static double Calculate(double num1, double num2, char operation)
    {
        switch (operation)
        {
            case '+':
                return num1 + num2;
            case '-':
                return num1 - num2;
            case '*':
                return num1 * num2;
            case '/':
                return num2 == 0 ? double.NaN : num1 / num2;
            default:
                return double.NaN;
        }
    }
}
