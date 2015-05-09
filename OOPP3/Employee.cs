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
        private int counter;

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
            increaseCounter();
            if (input.Length == 4)
            {
                lineInput = input;
                this.validateEmployeeID();
            }
            else
            {
                Console.WriteLine("Error on line {0}, the line is not the correct length", counter);
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
                Console.WriteLine("Error on line {0}, employee field is blank: \"{1}\"", counter, lineInput[0]);
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
                Console.WriteLine("Error on line {0}, department field is incorrect: \"{1}\"", counter, lineInput[1]);
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
                Console.WriteLine("Error on line {0}, hourly pay field is incorecct: \"{1}\"", counter, lineInput[2]);
            }
        }

        public void setHoursWorked()
        {
            if (decimal.TryParse(lineInput[3], out hoursWorked) && hoursWorked > 0.00m)
            {
                setDepartmentPay();
            }
            else
            {
                Console.WriteLine("Error one line {0}, hours worked field is incorrect: \"{1}\"", counter, lineInput[3]);
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
            Console.WriteLine("");
            Console.WriteLine("Department # ---------- Gross Pay");
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("{0, 12}    {1, 11}", i + 1,  departments[i].getDeparmentPay());
            }
        }

        public void increaseCounter()
        {
            counter += 1;
        }

    }
}
