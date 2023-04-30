using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
namespace HomeWork4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");
            if (args.Length > 0)
            {

                string inputFilename = args[0]; // создали строку для чтения
                string outputFilename = "solution.txt"; // создали строку для записи файла


                try
                {
                    using (StreamReader reader = new StreamReader(inputFilename))
                    {
                        using (StreamWriter writer = new StreamWriter(outputFilename, true))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                try
                                {
                                    Match match = Regex.Match(line, @"(\d+)\s*([-+*/])\s*(\d+)\s*=");
                                    if (match.Success)
                                    {
                                        int leftOperand = int.Parse(match.Groups[1].Value);
                                        char oper = match.Groups[2].Value[0];
                                        int rightOperand = int.Parse(match.Groups[3].Value);
                                        int result;
                                        switch (oper)
                                        {
                                            case '+': result = leftOperand + rightOperand; break;
                                            case '-': result = leftOperand - rightOperand; break;
                                            case '*': result = leftOperand * rightOperand; break;
                                            case '/': result = leftOperand / rightOperand; break;
                                            default: throw new InvalidOperationException($"Неизвестный оператор");
                                        }
                                        writer.WriteLine($"{line.Trim()} {result}");
                                    }
                                    else
                                    {
                                        writer.WriteLine($"{line.Trim()} ERROR: Invalid format");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    writer.WriteLine($"{line.Trim()} ERROR: {ex.Message}");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"ERROR: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Аргументы командной строки не переданы");
            }

            Console.WriteLine("Task 2");

            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    string inputFile = args[i];
                    string outputFile = $"solution{i}.txt";
                    try
                    {
                        using (StreamReader reader = new StreamReader(inputFile))
                        {
                            using (StreamWriter writer = new StreamWriter(outputFile, true))
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    try
                                    {
                                        Match match = Regex.Match(line, @"(\d+)\s*([-+*/])\s*(\d+)\s*=");
                                        if (match.Success)
                                        {
                                            int leftOperand = int.Parse(match.Groups[1].Value);
                                            char oper = match.Groups[2].Value[0];
                                            int rightOperand = int.Parse(match.Groups[3].Value);
                                            int result;
                                            switch (oper)
                                            {
                                                case '+': result = leftOperand + rightOperand; break;
                                                case '-': result = leftOperand - rightOperand; break;
                                                case '*': result = leftOperand * rightOperand; break;
                                                case '/': result = leftOperand / rightOperand; break;
                                                default: throw new InvalidOperationException($"Неизвестный оператор");
                                            }
                                            writer.WriteLine($"{line.Trim()} {result}");
                                        }
                                        else
                                        {
                                            writer.WriteLine($"{line.Trim()} ERROR: Invalid format");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        writer.WriteLine($"{line.Trim()} ERROR: {ex.Message}");
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"ERROR: {ex.Message}");
                    }

                }
            }
            else
            {
                Console.WriteLine("There is't arguments");
            }

            Console.WriteLine("Task3");

            Console.ReadLine();
        }
           
            
        }
    }

