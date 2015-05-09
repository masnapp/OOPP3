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
            Employee emp = new Employee();
            
            FileStream file = new FileStream("payroll.txt", FileMode.Open, FileAccess.Read);
            StreamReader payroll = new StreamReader(file);

            string line = payroll.ReadLine();
             
            
            while (line != null)
            {
                string[] fields = line.Split(',');

                emp.setLineInput(fields);

                line = payroll.ReadLine();
            }
            
        }
    }
}
