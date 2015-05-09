using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPP3
{
    class Employee
    {
        private Department[] departments;

        private int empDepNum;
        private decimal hourlyPay;
        private decimal hoursWorked;
        private string[] lineInput;


        public Employee()
        {
            departments = new Department[7];
            for (int i = 0; i < 7; i++)
            {
                departments[i] = new Department();
            }
        }

        public void setLineInput(string[] input)
        {// method that will determine that input is correct length
            if (input.Length == 4)
            {
                lineInput = input;
                this.validateEmployeeID();
            }
            else
            {
                Console.WriteLine("Error, the date line for this employee is not the correct length");
            }
        } // end setLineInput

        public void validateEmployeeID()
        {
            if (lineInput[0].Length != 0)
            {
                setDepartmentNumber();
            }
            else
            {
                Console.WriteLine("Error, the Employee number is blank");
            }
        }

        public void setDepartmentNumber()
        {
            if (int.TryParse(lineInput[1], out empDepNum) && empDepNum > 0 && empDepNum < 8)
            {
                setHourlyPay();
            }
            else
            {
                Console.WriteLine("Erorr with employees department number");
            }
        }

        public void setHourlyPay()
        {
            if (decimal.TryParse(lineInput[2], out hourlyPay) && hourlyPay >= 10.0m)
            {
                setHoursWorked();
            }
            else
            {
                Console.WriteLine("Error witht the employees hourly pay");
            }
        }

        public void setHoursWorked()
        {
            if (decimal.TryParse(lineInput[3], out hoursWorked) && hoursWorked > 0.00m)
            {
                setDepartmentPay();
            }
        }

        public decimal calculatePay()
        {
            decimal pay = hourlyPay*hoursWorked;
            return pay;
        }

        public void setDepartmentPay()
        {
            departments[empDepNum - 1].setDepartmentPay(calculatePay());
        }

        public void printDepartmentPay()
        {
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("{0} -- {1}", i + 1,  departments[i].getDeparmentPay());
            }
        }

    }
}
