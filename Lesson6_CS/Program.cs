using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lesson6_CS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //command line arguments - аргументы командной строки
            int lengthOfArgs = args.Length; // количество аргументов
            double number;
            
            Regex regex = new Regex(@"(-){0,1}(\d){1,}([\.\,]\d{1,}){0,}", 
                RegexOptions.IgnoreCase); //()-символ {} -количество []-перечисление 
            int counter = 0;
            foreach (string arg in args) // выводим все аргументы командной строки (можем переберать файлы)
            {
                string tmp = Regex.Replace(arg, @"\.", ",");
                MatchCollection matchCollection = regex.Matches(tmp);
                foreach (var item in matchCollection)
                {
                    counter++;
                    try
                    {
                        number = Double.Parse(item.ToString());
                        Console.WriteLine("Совпадение {0} имеет номер {1}", number, counter);
                    }
                    catch (Exception e00)
                    {
                        Console.WriteLine(e00.Message);
                        Console.WriteLine($"{item} не удалось преобразовать в Double.");
                    }                    
                }              
                
                /*try
                {
                    number = int.Parse(arg) * 2;
                    Console.WriteLine(number);
                }
                catch
                {
                    Console.WriteLine($"Ввод {arg} не распознан!");                    
                }
                finally 
                { 
                    Console.WriteLine("Этот код выпонится в любом случае");
                }*/   
            }
            Console.ReadKey();
        }
    }
}
