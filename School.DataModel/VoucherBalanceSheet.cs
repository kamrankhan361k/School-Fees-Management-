using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DataModel
{
    public class VoucherBalanceSheet
    {
        public int ID { get; set; }

        public DateTime CreatedDate { get; set; }

        public string  Particular { get; set; }

        public string  Standard { get; set; }

        public string  VoucherNumber { get; set; }

        public double Dr { get; set; }

        public double Cr { get; set; }
    }
}
