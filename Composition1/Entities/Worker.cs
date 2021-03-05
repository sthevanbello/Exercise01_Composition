using Composition1.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition1.Entities
{
    class Worker { 
    
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();




        public Worker() 
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department departments)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = departments;
        } 

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sumIncome = BaseSalary;

            foreach (var item in Contracts)
            {
                if (item.Date.Year == year && item.Date.Month == month)
                {
                    sumIncome += item.TotalValue();
                }

            }
            return sumIncome;
        }



    }
}
