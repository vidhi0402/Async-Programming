using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReadCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            Method1();
            Method2();
            Method3();
            Console.ReadKey();

        }
        public static async Task Method1()
        {           
            await Task.Run(()=>
            {
                string path = (@"C:\Users\vidhi\Desktop\Blazor\ReadCSV\CSVFiles\Employee_Vidhi_1.csv");
                string[] lines = System.IO.File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    Console.WriteLine("Employee_Vidhi_1" + " ---> "+line);
                    Console.WriteLine();                   
                }                   
            });           
        }

        public static async Task Method2()
        {            
            await Task.Run(() =>
            {
                string path = (@"C:\Users\vidhi\Desktop\Blazor\ReadCSV\CSVFiles\Employee_Vidhi_2.csv");
                string[] lines = System.IO.File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    Console.WriteLine("Employee_Vidhi_2" + " ---> " + line);
                    Console.WriteLine();
                }
            });
        }

        public static async Task Method3()
        {           
            await Task.Run(() =>
            {
                string path = (@"C:\Users\vidhi\Desktop\Blazor\ReadCSV\CSVFiles\Employee_Vidhi_3.csv");
                string[] lines = System.IO.File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    Console.WriteLine("Employee_Vidhi_3" + " ---> " + line);
                    Console.WriteLine();
                }                   
            });
        }
    }
}

