using Composition1.Entities;
using Composition1.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition1
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter department's name: ");
            string departmentName = Console.ReadLine();

            Console.WriteLine("Enter worker data: ");

            Console.Write("Name: ");
            string workerName = Console.ReadLine();

            Console.Write("Level (Junior/MidLevel/Senior: ");

            string levelName = Console.ReadLine();

            WorkerLevel level = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), levelName);

            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine());

            Department department = new Department(departmentName);

            Worker worker = new Worker(name: workerName, level: level, baseSalary: baseSalary, departments: department);

            Console.Write("How many contracts to this worker? ");
            int numberContracts = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberContracts; i++)
            {
                Console.WriteLine($"Enter the #{i} data: ");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine());

                Console.Write("Duration (Hours): ");
                int hours = int.Parse(Console.ReadLine());


                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
                
            }

            Console.WriteLine();

            Console.Write("Enter month and year to calculate income (MM/YYY): ");

            string dateIncome = Console.ReadLine();

            int month = int.Parse(dateIncome.Substring(0,2));
            int year = int.Parse(dateIncome.Substring(3));

            #region Alternative

            //string[] dateIncome = Console.ReadLine().Split('/');

            //int month = int.Parse(dateIncome[0]);
            //int year = int.Parse(dateIncome[1]);

            //DateTime dateIncome = DateTime.Parse(Console.ReadLine());

            //int month = dateIncome.Month;
            //int year = dateIncome.Year;

            #endregion

            Console.WriteLine();

            Console.WriteLine($"Name: {worker.Name}");
            Console.WriteLine($"Department: {worker.Department.Name}");
            Console.WriteLine($"Income for {month:D2}/{year}: {worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture)}");


            Console.ReadKey();
        }
    }
}
