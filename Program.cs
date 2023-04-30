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

            if(args.Length > 0)
            {
                string directory = args[0]; // аргумент командной строки - директория
                if(Directory.Exists(directory)) // проверка
                {
                    Console.WriteLine("Подкаталоги:");
                    string[] dirs = Directory.GetDirectories(directory); // получаем подкаталоги
                    foreach (string s in dirs)
                    {
                        Console.WriteLine(s); //вывод
                    }
                    Console.WriteLine();
                    Console.WriteLine("Файлы:"); // получаем спискок файлов
                    string[] files = Directory.GetFiles(directory);
                    foreach (string s in files)
                    {
                        Console.WriteLine(s);//вывод
                    }
                }
            }
            else
            {
                Console.WriteLine(Directory.GetCurrentDirectory()); 
            }


            Console.WriteLine("Task4");
            // Есть каталог A где хранятся файл с общим доступом и каталог B, где хранятся копии этого файла(с суфиксом времени копирования) для
            // возможности восстановления.
            //Программа должна проверять время изменения файла в каталоге А и создавать его копию в каталоге B, если время его изменения позже,
            //чем последнее время изменения в каталоге копий.

            string catalog_A = @"C:\Users\nosychev\Desktop\Programmatic\С#\HomeWork4\HomeWork4\bin\Debug";
            string catalog_B = @"C:\Users\nosychev\Desktop\Programmatic\С#\HomeWork4\HomeWork4\bin";
            Directory.GetCreationTime(catalog_A); // метод получения времени каталога 1
            Directory.GetCreationTime(catalog_B); // метод получения времени каталога 2
            if (Directory.GetCreationTime(catalog_A) > Directory.GetCreationTime(catalog_B))
            {
                File.Copy(catalog_A, catalog_B, true);
            }



            Console.ReadLine();
        }
           
            
        }
    }

