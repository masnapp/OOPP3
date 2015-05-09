using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPP3
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize employee object
            Employee emp = new Employee();
            
            // read payroll file 
            FileStream file = new FileStream("payroll.txt", FileMode.Open, FileAccess.Read);
            using(StreamReader payroll = new StreamReader(file))
            {
                // string to hold each line from file
                string line = payroll.ReadLine();

                while (line != null)
                {
                    string[] fields = line.Split(',');

                    emp.setLineInput(fields);

                    line = payroll.ReadLine();
                }

                emp.printDepartmentPay();
            }
        }
    }
}
