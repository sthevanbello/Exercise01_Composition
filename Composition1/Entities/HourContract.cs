using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composition1.Entities
{
    class HourContract
    {
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }

        public int Hours { get; set; }


        public HourContract()
        {

        }

        public HourContract(DateTime date, double valuPerHour, int hours)
        {
            Date = date;
            ValuePerHour = valuPerHour;
            Hours = hours;

        }

        public double TotalValue()
        {
            return ValuePerHour * Hours;
        }

    }
}
