using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpIntermediateAssign.Interface;

namespace CSharpIntermediateAssign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Calculator");
            Console.WriteLine("1. Basic Calculator (Default selection)");
            Console.WriteLine("2. Advanced Calculator");

            Console.WriteLine();

            string ch;

            while (true)
            {
                Console.WriteLine("Enter your choice (1 or 2)");
                ch = Console.ReadLine().Trim();

                if (ch == "1" || ch == "2")
                {
                    break;
                }

                Console.WriteLine("Invalid Choice, Please Enter 1 or 2.");
            }

            ICalculator calculator;

            if (ch == "2")
            {
                calculator = new AdvancedCalculator();
            }
            else
            {
                calculator = new Calculator();
            }

            while (true)
            {
                Console.WriteLine("\nCalculator Menu :");
                Console.WriteLine("1. Add 2 Integers");
                Console.WriteLine("2. Add 3 Integers");
                Console.WriteLine("3. Add 2 Floating Point Numbers");

                if (calculator is IAdvancedCalculator)
                {
                    Console.WriteLine("4. Power");
                }
                /*
                 This checks if object currently stored inside 'calculator' var implements IAdvanceCalculator
                 */

                Console.WriteLine("5. Get Result");
                Console.WriteLine("0. Exit");

                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine().Trim();

                switch (choice)
                {
                    case "1":
                    {
                        if (!ValidateInt("Enter first integer: ", out int num1))
                            break;
                        if (!ValidateInt("Enter Second integer: ", out int num2))
                            break;

                        Console.WriteLine($"Result = {calculator.Add(num1, num2)}");
                        break;
                    }

                    case "2":
                    {
                        if (!ValidateInt("Enter first integer: ", out int num1))
                            break;
                        if (!ValidateInt("Enter Second integer: ", out int num2))
                            break;
                        if (!ValidateInt("Enter Third integer: ", out int num3))
                            break;

                        Console.WriteLine($"Result = {calculator.Add(num1, num2, num3)}");
                        break;
                    }

                    case "3":
                    {
                        if (!ValidateFloat("Enter first Float Number: ", out float num1))
                            break;
                        if (!ValidateFloat("Enter Second Float Number: ", out float num2))
                            break;

                        Console.WriteLine($"Result = {calculator.Add(num1, num2)}");
                        break;
                    }

                    case "4":
                    {
                        if (calculator is IAdvancedCalculator advancedCalculator)
                        {
                            if (!ValidateInt("Enter Base : ", out int baseNum))
                                break;
                            if (!ValidateInt("Enter Exponent : ", out int exponent))
                                break;

                                Console.WriteLine($"Result = {advancedCalculator.Power(baseNum, exponent)}");
                        }
                        else
                        {
                            Console.WriteLine("Power Application is only applicable for Advance Calculator");
                        }
                        break;
                    }

                    case "5":
                    {
                        Console.WriteLine($"Latest Result  = {calculator.GetResult()}");
                        break;
                    }

                    case "0":
                    {
                        Console.WriteLine("Exiting..");
                        return;
                    }

                    default:
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                    }
                }
            }

        }

        public static bool ValidateInt(string message, out int value)
        {
            Console.WriteLine(message);

            if(!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid Integer.");
                return false;
            }
            return true;
        }

        public static bool ValidateFloat(string message, out float value)
        {
            Console.WriteLine(message);

            if (!float.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Invalid Integer.");
                return false;
            }
            return true;
        }
    }
}
