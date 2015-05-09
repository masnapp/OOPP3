using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPP3
{
    class Department
    {
        private decimal totalDepartmentPay;

        public void setDepartmentPay(decimal pay)
        {
            totalDepartmentPay += pay;
        }

        public decimal getDeparmentPay()
        {
            return totalDepartmentPay;
        }

    }
}
