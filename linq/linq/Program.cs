using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using test.Entities;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter full file path: ");
            string path = Console.ReadLine();

            Console.Write("Enter Salary: ");
            double trueSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Employee> list = new List<Employee>();
            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    string email = fields[1];
                    double salary = double.Parse(fields[2], CultureInfo.InvariantCulture);
                    list.Add(new Employee(name, email, salary));
                }

                var emls = list.Where(obj => obj.Salary > trueSalary).OrderBy(obj => obj.Email).Select(obj => obj.Email);

                var sM = list.Where(obj => obj.Name[0] == 'M').Sum(obj => obj.Salary);

                Console.WriteLine("Email of people whose salary is more than 2000.00 " + trueSalary.ToString("F2", CultureInfo.InvariantCulture));
                foreach (var mt in emls)
                {
                    Console.WriteLine(mt);
                }

                Console.WriteLine($"sum of salary of people whose name starts with 'M': " + sM.ToString("F2", CultureInfo.InvariantCulture));
            }
        }
    }
}